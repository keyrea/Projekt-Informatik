using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class AtributeInitialization : MonoBehaviour // инициализация 4 показателей
{
    public Text show_current_day;
    public Text show_current_health; // текстовое поле для значения "Здоровье"
    public Text show_current_progress; // текстовое поле для значения "Знания"
    public Text show_current_money; // текстовое поле для значения "Деньги"
    public Text show_current_time; // текстовое поле для значения "Время"

    int current_day;
    int current_health;
    int current_time;
    int current_progress;
    int current_money;

   public void Start()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/Main_DB";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDataReader init_player;
        IDbCommand get_attr = dbcon.CreateCommand();
        get_attr.CommandText = "SELECT * FROM Player";
        init_player = get_attr.ExecuteReader();

        current_day = Convert.ToInt32(init_player["day"].ToString());
        current_time = Convert.ToInt32(init_player["current_time"].ToString());
        current_health = Convert.ToInt32(init_player["current_health"].ToString());
        current_progress = Convert.ToInt32(init_player["current_progress"].ToString());
        current_money = Convert.ToInt32(init_player["current_money"].ToString());

        dbcon.Close();

        show_current_day.text = current_day.ToString();
        show_current_time.text = current_time.ToString();
        show_current_health.text = current_health.ToString();
        show_current_progress.text = current_progress.ToString();
        show_current_money.text = current_money.ToString();
    }
    /*
    public int Health
    {
        get { return health; }
        set { health = Health; }
    }

    public int Study
    {
        get { return study; }
        set { study = Study; }
    }

    public float Money
    {
        get { return money; }
        set { money = Money; }
    }

    public float Time
    {
        get { return time; }
        set { time = Time; }
    }
    */

}
