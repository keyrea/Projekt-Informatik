// using System.Collections;
// using System.Collections.Generic;
// using Mono.Data.Sqlite;
// using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class AtributeChange : MonoBehaviour
{
    public GameObject sceneManager; // ссылка на объект отвечающий за переход между сценами
    public Text get_question_category; // текстовое поле с категорией вопроса
    public Text get_current_day; // текстовое поле с номером текущего дня
    public Text get_current_mental; // текстовое поле для значения "Ментальное здоровье"
    public Text get_current_health; // текстовое поле для значения "Здоровье"
    public Text get_current_progress; // текстовое поле для значения "Знания"
    public Text get_current_money; // текстовое поле для значения "Деньги"

    public Text get_yes_mental; // текстовое поле для значения "Ментальное здоровье" ответа "да"
    public Text get_yes_health; // текстовое поле для значения "Здоровье" ответа "да"
    public Text get_yes_progress; // текстовое поле для значения "Знания" ответа "да"
    public Text get_yes_money; // текстовое поле для значения "Деньги" ответа "да"

    public Text get_no_mental; // текстовое поле для значения "Ментальное здоровье" ответа "нет"
    public Text get_no_health; // текстовое поле для значения "Здоровье" ответа "нет"
    public Text get_no_progress; // текстовое поле для значения "Знания" ответа "нет"
    public Text get_no_money; // текстовое поле для значения "Деньги" ответа "нет"

    public void changeAtribute(string answer_type)// получает тип ответа да/нет
    {
        // запрос в БД
        string result = "";
        // значение для проверки полявления случайного событя
        bool event_was = false;
        // категория вопроса
        int question_type = int.Parse(get_question_category.text.ToString());

        // новые текущие занчения параметров (по умолчания хранят старые текущие значения)
        int new_current_day = int.Parse(get_current_day.text.ToString());
        int new_current_mental = int.Parse(get_current_mental.text.ToString());
        int new_current_health = int.Parse(get_current_health.text.ToString());
        int new_current_progress = int.Parse(get_current_progress.text.ToString());
        int new_current_money = int.Parse(get_current_money.text.ToString());

        // значения блокировки парамертра
        int new_curent_block_mental = 0;
        int new_curent_block_health = 0;
        int new_curent_block_progress = 0;
        int new_curent_block_money = 0;

        // если тип ответа "да" прибавить к текущим значениям значения ответа "да"
        if (answer_type == "yes")
        {
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental += int.Parse(get_yes_mental.text.ToString());
            new_current_health += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money += int.Parse(get_yes_money.text.ToString());
        }
        // если тип ответа "нет" прибавить к текущим значениям значения ответа "нет"
        else if (answer_type == "no")
        {
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental += int.Parse(get_no_mental.text.ToString());
            new_current_health += int.Parse(get_no_health.text.ToString());
            new_current_progress += int.Parse(get_no_progress.text.ToString());
            new_current_money += int.Parse(get_no_money.text.ToString());
        }
        // если тип ответа "ок" прибавить к текущим значениям значения ответа "ок"
        else if (answer_type == "ok")
        {
            new_current_day = int.Parse(get_current_day.text.ToString());
            new_current_mental += int.Parse(get_yes_mental.text.ToString());
            new_current_health += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money += int.Parse(get_yes_money.text.ToString());
            // установить проверки появления случайного события на "true"(уже появлялось)
            event_was = true;
        }

        // если текущее значение превысило 10, то опустить его до 10
        if (new_current_mental > 10) { new_current_mental = 10; }
        if (new_current_health > 10) { new_current_health = 10; }
        if (new_current_progress > 10) { new_current_progress = 10; }
        if (new_current_money > 10) { new_current_money = 10; }

        // заблокировать параметр взависимости от категории вопроса
        if (question_type == 1) { new_curent_block_mental = 1; }
        else if (question_type == 2) { new_curent_block_health = 1; }
        else if (question_type == 3) { new_curent_block_progress = 1; }
        else if (question_type == 4) { new_curent_block_money = 1; }

        // формирование и отрпвака запроса в БД 
        result = MyDataBase.ExecuteQueryWithAnswer("UPDATE Player " +
                                            "SET day =" + new_current_day + "," +
                                            "current_mental =" + new_current_mental + "," +
                                            "current_health =" + new_current_health + "," +
                                            "current_progress =" + new_current_progress + "," +
                                            "current_money =" + new_current_money + "," +
                                            "block_mental =" + new_curent_block_mental + "," +
                                            "block_health =" + new_curent_block_health + "," +
                                            "block_progress =" + new_curent_block_progress + "," +
                                            "block_money =" + new_curent_block_money + " " +
                                            "WHERE ID_player = 1;");

        // если текущее значение опустилось до 0 или ниже, перейти в сцену результатов
        if (new_current_mental <= 0 || new_current_health <= 0 ||
            new_current_progress <= 0 || new_current_money <= 0)
        {
            sceneManager.GetComponent<ChangeScene>().NextScene(7);
        }
        // иначе перейти в меню выбора категории вопроса или запустить случайное событие
        else
        {
            // случайное значение случайного события
            System.Random randomEventChance = new System.Random();
            int eventChance = randomEventChance.Next(0, 100);
            Debug.Log(eventChance);

            // шанс случайного события 10%, если случайное значение подходит, запускается случайное событие
            if (event_was == false && eventChance >= 0 && eventChance <= 10)
            {
                sceneManager.GetComponent<ChangeScene>().NextScene(6);
            }
            // иначе запускается сцена выбора категрии вопроса
            else
            {
                sceneManager.GetComponent<ChangeScene>().NextScene(1);
            }
        }
    }
}
