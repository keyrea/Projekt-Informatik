// using System;
using UnityEngine;
using System.Data;
// using Mono.Data.Sqlite;
// using System.IO;
using UnityEngine.UI;

public class AtributeQuestionInitialization : MonoBehaviour
{
    public Text show_question; // текстовое поле с вопросом
    public Text show_question_category; // текстовое поле с категорией вопроса

    public Text show_yes_mental; // текстовое поле для значения "Ментальное здоровье" ответа "да"
    public Text show_yes_health; // текстовое поле для значения "Здоровье" ответа "да"
    public Text show_yes_progress; // текстовое поле для значения "Знания" ответа "да"
    public Text show_yes_money; // текстовое поле для значения "Деньги" ответа "да"

    public Text show_no_mental; // текстовое поле для значения "Ментальное здоровье" ответа "нет"
    public Text show_no_health; // текстовое поле для значения "Здоровье" ответа "нет"
    public Text show_no_progress; // текстовое поле для значения "Знания" ответа "нет"
    public Text show_no_money; // текстовое поле для значения "Деньги" ответа "нет"
    public int get_question_category_int; // численное значение категории вопроса

    // Start is called before the first frame update
    void Start()
    {
        // численное значение категории вопроса
        int question_category = get_question_category_int;

        // получаем максимальный и минимальный id вопросов выбранной категории
        DataTable selectIDmin = MyDataBase.GetTable("SELECT min(ID_question) FROM Question " +
                                                    "WHERE question_category = " + question_category + ";");
        DataTable selectIDmax = MyDataBase.GetTable("SELECT max(ID_question) FROM Question " +
                                                    "WHERE question_category = " + question_category + ";");
        int IDmin = int.Parse(selectIDmin.Rows[0][0].ToString());
        int IDmax = int.Parse(selectIDmax.Rows[0][0].ToString()) + 1;

        // выбор случайного id в промежутке между максимальным и минимальным id вопросов выбранной категории
        System.Random randomDirection = new System.Random();
        int question_id = randomDirection.Next(IDmin, IDmax);

        // получаем случайный вопрос с параметрами выбранной категории
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Question " +
                                                        "WHERE ID_question = " + question_id +
                                                        " AND question_category = " + question_category + ";");

        // отображаем полученный вопрос с параметрами
        show_question.text = questionData.Rows[0][2].ToString();
        show_question_category.text = question_category.ToString();

        show_yes_mental.text = questionData.Rows[0][3].ToString();
        show_yes_health.text = questionData.Rows[0][4].ToString();
        show_yes_progress.text = questionData.Rows[0][5].ToString();
        show_yes_money.text = questionData.Rows[0][6].ToString();

        show_no_mental.text = questionData.Rows[0][7].ToString();
        show_no_health.text = questionData.Rows[0][8].ToString();
        show_no_progress.text = questionData.Rows[0][9].ToString();
        show_no_money.text = questionData.Rows[0][10].ToString();

        // старый вариант кода сверху
        // string questionText = questionData.Rows[0][2].ToString();
        // int yesMental = int.Parse(questionData.Rows[0][3].ToString());
        // int yesHealth = int.Parse(questionData.Rows[0][4].ToString());
        // int yesProgrgess = int.Parse(questionData.Rows[0][5].ToString());
        // int yesMoney = int.Parse(questionData.Rows[0][6].ToString());
        // int noMental = int.Parse(questionData.Rows[0][7].ToString());
        // int noHealth = int.Parse(questionData.Rows[0][8].ToString());
        // int noProgrgess = int.Parse(questionData.Rows[0][9].ToString());
        // int noMoney = int.Parse(questionData.Rows[0][10].ToString());

        // show_question.text = questionText;
        // show_question_category.text = question_category.ToString();
        // show_yes_mental.text = yesMental.ToString();
        // show_yes_health.text = yesHealth.ToString();
        // show_yes_progress.text = yesProgrgess.ToString();
        // show_yes_money.text = yesMoney.ToString();
        // show_no_mental.text = noMental.ToString();
        // show_no_health.text = noHealth.ToString();
        // show_no_progress.text = noProgrgess.ToString();
        // show_no_money.text = noMoney.ToString();
    }
}
