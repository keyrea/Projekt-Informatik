using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.SceneManagement;


public class SQLiteTest : MonoBehaviour
{
    public int loadGame;
    // Start is called before the first frame update
    public void Start()
    {
        // Открываю соединение с БД
        string connection = "URI=file:" + Application.persistentDataPath + "/Main_DB";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();
        
        // Создаю таблицы Question и Player, если они не существуют
        IDbCommand dbcmd_question;
        dbcmd_question = dbcon.CreateCommand();
        string q_createTables = "CREATE TABLE IF NOT EXISTS Question (ID_question INTEGER NOT NULL, question_category INTEGER NOT NULL, question_text TEXT NOT NULL, yes_time  INTEGER NOT NULL, yes_health    INTEGER NOT NULL, yes_progress  INTEGER NOT NULL, yes_money INTEGER NOT NULL, no_time   INTEGER NOT NULL, no_health INTEGER NOT NULL, no_progress   INTEGER NOT NULL, no_money  INTEGER NOT NULL, PRIMARY KEY(ID_question)); CREATE TABLE IF NOT EXISTS PLayer (ID_player INTEGER NOT NULL, day   INTEGER NOT NULL, current_time  INTEGER NOT NULL, current_health    INTEGER NOT NULL, current_progress  INTEGER NOT NULL, current_money INTEGER NOT NULL, PRIMARY KEY(ID_player AUTOINCREMENT));";
        dbcmd_question.CommandText = q_createTables;
        dbcmd_question.ExecuteReader();
        
        // Подсчёт строк в таблице Player, чтобы убедиться, нужно ли вносить записи
        IDataReader rows_in_player;
        IDbCommand table_empty_player = dbcon.CreateCommand();
        table_empty_player.CommandText = "SELECT COUNT(*) AS Rows FROM Player";
        rows_in_player = table_empty_player.ExecuteReader();

        int rows_player = Convert.ToInt32(rows_in_player["Rows"].ToString());

        if (rows_player == 0) // Если количество строк равно 0, то будет осуществлена запись в таблицу Player
        {
            IDbCommand cmnd_for_player = dbcon.CreateCommand();
            cmnd_for_player.CommandText = "INSERT INTO Player (day,current_time,current_health,current_progress,current_money) VALUES (100,100,100,100,1000);";
            cmnd_for_player.ExecuteNonQuery();
            Debug.Log("Запись вставлена в таблицу Player. Количество записей: " + rows_player.ToString());   
        }

        else
        {
            Debug.Log("Запись уже имеется в таблице Player. Количество записей:  " + rows_player.ToString());
        }


        // Подсчёт строк в таблице Question
        IDataReader rows_in_question;
        IDbCommand table_empty_question = dbcon.CreateCommand();
        table_empty_question.CommandText = "SELECT COUNT(*) AS Rows FROM Question";
        rows_in_question = table_empty_question.ExecuteReader();

        int rows_question = Convert.ToInt32(rows_in_question["Rows"].ToString());

        if(rows_question == 0)
        {
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = "INSERT INTO Question (question_category,question_text,yes_time,yes_health,yes_progress,yes_money,no_time,no_health,no_progress,no_money) VALUES (4,'Sie müssen mit dem Zug zu Ihrem Hostel gelangen. Aber Sie möchten bei Ihrem Ticket sparen und Ihre Ankunft spülen. So gehen Sie vor: den Fahrpreis nicht bezahlen oder trotzdem zahlen?',0,0,0,-20,0,0,0,-60);";
            cmnd.ExecuteNonQuery();
            Debug.Log("Запись вставлена в таблицу Question. Количество записей: " + rows_question.ToString());
        }
        else
        {
            Debug.Log("Записи уже имеются в таблице Question. Количество записей: " + rows_question.ToString());
        }
       

        /*
        IDbCommand del = dbcon.CreateCommand();
        del.CommandText = "DROP TABLE Question; DROP TABLE Player";
        del.ExecuteNonQuery();
        */

        dbcon.Close();

        SceneManager.LoadScene(loadGame);
    }

}
