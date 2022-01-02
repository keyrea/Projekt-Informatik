using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class AtributeQuestionInitialization : MonoBehaviour
{
    public Text show_question;

    public Text show_yes_health;
    public Text show_yes_time;
    public Text show_yes_progress;
    public Text show_yes_money;

    public Text show_no_health;
    public Text show_no_time;
    public Text show_no_progress;
    public Text show_no_money;

    string question;

    int yes_health;
    int yes_time;
    int yes_progress;
    int yes_money;

    int no_health;
    int no_time;
    int no_progress;
    int no_money;

    // Start is called before the first frame update
    void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/Main_DB";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDataReader points;
        IDbCommand get_points = dbcon.CreateCommand();
        get_points.CommandText = "SELECT * FROM Question";
        points = get_points.ExecuteReader();

        question = points["question_text"].ToString();

        yes_health = Convert.ToInt32(points["yes_health"].ToString());
        yes_time = Convert.ToInt32(points["yes_time"].ToString());
        yes_progress = Convert.ToInt32(points["yes_progress"].ToString());
        yes_money = Convert.ToInt32(points["yes_money"].ToString());

        no_health = Convert.ToInt32(points["no_health"].ToString());
        no_time = Convert.ToInt32(points["no_time"].ToString());
        no_progress = Convert.ToInt32(points["no_progress"].ToString());
        no_money = Convert.ToInt32(points["no_money"].ToString());

        dbcon.Close();

        show_question.text = question.ToString();

        show_yes_health.text = yes_health.ToString();
        show_yes_time.text = yes_time.ToString();
        show_yes_progress.text = yes_progress.ToString();
        show_yes_money.text = yes_money.ToString();

        show_no_health.text = no_health.ToString();
        show_no_time.text = no_time.ToString();
        show_no_progress.text = no_progress.ToString();
        show_no_money.text = no_money.ToString();

    }

}
