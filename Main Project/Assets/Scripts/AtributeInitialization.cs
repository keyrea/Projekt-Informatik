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
    public Text show_current_mental; // текстовое поле для значения "Ментальное здоровье"

    public void Start()
    {

        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Player WHERE ID_player = 1;");
        // Получаем текст вопроса
        // string questionText = int.Parse(questionData.Rows[0][0].ToString());
        int current_day = int.Parse(questionData.Rows[0][1].ToString());
        int current_mental = int.Parse(questionData.Rows[0][2].ToString());
        int current_health = int.Parse(questionData.Rows[0][3].ToString());
        int current_progress = int.Parse(questionData.Rows[0][4].ToString());
        int current_money = int.Parse(questionData.Rows[0][5].ToString());

        show_current_day.text = current_day.ToString();
        show_current_mental.text = current_mental.ToString();
        show_current_health.text = current_health.ToString();
        show_current_progress.text = current_progress.ToString();
        show_current_money.text = current_money.ToString();

    }

}
