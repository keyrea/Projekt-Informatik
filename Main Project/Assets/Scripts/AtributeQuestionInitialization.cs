using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class AtributeQuestionInitialization : MonoBehaviour
{

    public Text show_question;

    public Text show_yes_mental;
    public Text show_yes_health;
    public Text show_yes_progress;
    public Text show_yes_money;

    public Text show_no_mental;
    public Text show_no_health;
    public Text show_no_progress;
    public Text show_no_money;


    string question;

    int yes_mental;
    int yes_health;
    int yes_progress;
    int yes_money;

    int no_mental;
    int no_health;
    int no_progress;
    int no_money;


    // String db_name = "Main_DB";

    // Start is called before the first frame update
    void Start()
    {
        System.Random randomDirection = new System.Random();

        int question_category = 1;

        // тут внесены мои изменения
        DataTable selectIDmin = MyDataBase.GetTable("SELECT min(ID_question) FROM Question WHERE question_category = "+question_category+";");
        DataTable selectIDmax = MyDataBase.GetTable("SELECT max(ID_question) FROM Question WHERE question_category = " + question_category + ";");

        int IDmin = int.Parse(selectIDmin.Rows[0][0].ToString());
        int IDmax = int.Parse(selectIDmax.Rows[0][0].ToString());

        int question_id = randomDirection.Next(IDmin, IDmax);
        // тут заканчиваются мои изменения

        // Получаем таблицу Question
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Question WHERE ID_question ="+question_id+" AND question_category ="+question_category+";");
        // Получаем текст вопроса
        // string questionText = int.Parse(questionData.Rows[0][0].ToString());
        string questionText = questionData.Rows[0][2].ToString();
        int yesMental = int.Parse(questionData.Rows[0][3].ToString());
        int yesHealth = int.Parse(questionData.Rows[0][4].ToString());
        int yesProgrgess = int.Parse(questionData.Rows[0][5].ToString());
        int yesMoney = int.Parse(questionData.Rows[0][6].ToString());
        int noMental = int.Parse(questionData.Rows[0][7].ToString());
        int noHealth = int.Parse(questionData.Rows[0][8].ToString());
        int noProgrgess = int.Parse(questionData.Rows[0][9].ToString());
        int noMoney = int.Parse(questionData.Rows[0][10].ToString());
        
        // string nickname = MyDataBase.ExecuteQueryWithAnswer($"SELECT day FROM Player WHERE id = {idPlayer};");
        // Debug.Log($"Вопрос {idQuestion} с текстом '{questionData.Rows[0][2].ToString()}'.");

        show_question.text = questionText;

        show_yes_mental.text = yesMental.ToString();
        show_yes_health.text = yesHealth.ToString();
        show_yes_progress.text = yesProgrgess.ToString();
        show_yes_money.text = yesMoney.ToString();

        show_no_mental.text = noMental.ToString();
        show_no_health.text = noHealth.ToString();
        show_no_progress.text = noProgrgess.ToString();
        show_no_money.text = noMoney.ToString();
        
    }

}
