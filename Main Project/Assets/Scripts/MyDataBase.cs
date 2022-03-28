using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


static class MyDataBase
{
    private const string fileName = "Main_DB.db";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;

    static MyDataBase()
    {
        DBPath = GetDatabasePath();
    }

    /// <summary> Returns the path to the database. If it is not in the desired folder on Android, then it copies it from the original apk file. </summary>
    private static string GetDatabasePath()
    {
        #if UNITY_EDITOR
            return Path.Combine(Application.streamingAssetsPath, fileName);
        #elif UNITY_STANDALONE
            string filePath = Path.Combine(Application.dataPath, fileName);
            if(!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
        #elif UNITY_ANDROID
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            if(!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
        #endif
    }

    /// <summary> Unpacks the database to the specified path. </summary>
    /// <param name="toPath"> The path to which to unpack the database. </param>
    private static void UnpackDatabase(string toPath)
    {
        string fromPath = Path.Combine(Application.streamingAssetsPath, fileName);

        // UnityWebRequest is offered as an alternative to WWW
        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }
        File.WriteAllBytes(toPath, reader.bytes);
        // but UnityWebRequest doesn't work on android
    }

    /// <summary> This method opens a connection to the database. </summary>
    private static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + DBPath);
        command = new SqliteCommand(connection);
        connection.Open();
    }

    /// <summary> This method closes the database connection. </summary>
    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }

    /// <summary> This method executes a query. </summary>
    /// <param name="query"> Request text. </param>
    public static void ExecuteQueryWithoutAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        command.ExecuteNonQuery();
        CloseConnection();
    }

    /// <summary> This method executes a query and returns the query response. </summary>
    /// <param name="query"> Request text. </param>
    /// <returns> Returns the value of row 1 of column 1, if any. </returns>
    public static string ExecuteQueryWithAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }

    /// <summary> This method returns a table that is the result of a query query. </summary>
    /// <param name="query"> Request text. </param>
    public static DataTable GetTable(string query)
    {
        OpenConnection();

        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();

        CloseConnection();

        return DS.Tables[0];
    }
}
