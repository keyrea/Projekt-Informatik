using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class AtributeChange : MonoBehaviour 
{
    public GameObject myGameObject;
    public Text get_current_day;
    public Text get_current_mental; // текстовое поле для значения "Ментальное здоровье"
    public Text get_current_health; // текстовое поле для значения "Здоровье"
    public Text get_current_progress; // текстовое поле для значения "Знания"
    public Text get_current_money; // текстовое поле для значения "Деньги"

    public Text get_yes_mental; // текстовое поле для значения "да Ментальное здоровье"
    public Text get_yes_health; // текстовое поле для значения "да Здоровье"
    public Text get_yes_progress; // текстовое поле для значения "да Знания"
    public Text get_yes_money; // текстовое поле для значения "да Деньги"
    
    public Text get_no_mental; // текстовое поле для значения "да Ментальное здоровье"
    public Text get_no_health; // текстовое поле для значения "да Здоровье"
    public Text get_no_progress; // текстовое поле для значения "да Знания"
    public Text get_no_money; // текстовое поле для значения "да Деньги"

    public void changeAtribute(string answer_type){// тип ответа да/нет
        // новые текущие занчения параметров
        string result = "";
        bool event_was = false;
        int new_current_day = int.Parse(get_current_day.text.ToString());
        int new_current_mental = int.Parse(get_current_mental.text.ToString());
        int new_current_health = int.Parse(get_current_health.text.ToString());
        int new_current_progress = int.Parse(get_current_progress.text.ToString());
        int new_current_money = int.Parse(get_current_money.text.ToString());

        if (answer_type == "yes"){
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental   += int.Parse(get_yes_mental.text.ToString());
            new_current_health   += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money    += int.Parse(get_yes_money.text.ToString());
        } else if (answer_type == "no"){
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental   += int.Parse(get_no_mental.text.ToString());
            new_current_health   += int.Parse(get_no_health.text.ToString());
            new_current_progress += int.Parse(get_no_progress.text.ToString());
            new_current_money    += int.Parse(get_no_money.text.ToString());
        } else if (answer_type == "ok"){
            new_current_day = int.Parse(get_current_day.text.ToString());
            new_current_mental   += int.Parse(get_yes_mental.text.ToString());
            new_current_health   += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money    += int.Parse(get_yes_money.text.ToString());
            event_was = true;
        } 

        // если текущее значение превысило 10, то опустить его до 10
        if(new_current_mental > 10){new_current_mental = 10;}
        if(new_current_health > 10){new_current_health = 10;}
        if(new_current_progress > 10){new_current_progress = 10;}
        if(new_current_money > 10){new_current_money = 10;} 

        result = MyDataBase.ExecuteQueryWithAnswer("UPDATE Player " + 
                                            "SET day ="+ new_current_day + "," + 
                                            "current_mental ="+ new_current_mental + "," + 
                                            "current_health ="+ new_current_health + "," + 
                                            "current_progress ="+ new_current_progress + "," + 
                                            "current_money ="+ new_current_money + " " + 
                                            "WHERE ID_player = 1;");

        // если текущее значение опустилось до 0 или ниже, перейти в сцену результатов
        if (new_current_mental <= 0 || new_current_health <= 0 ||
            new_current_progress <= 0 || new_current_money <= 0){
                myGameObject.GetComponent<ChangeScene>().NextScene(7);
        } else { //иначе перейти в меню выбора вопроса или запустить случайное событие
            System.Random randomEventChance = new System.Random();
            int eventChance = randomEventChance.Next(0, 100);
            Debug.Log(eventChance);
            if (event_was == false && eventChance >= 0 && eventChance <= 10){//шанс сулчайного события 10%
                myGameObject.GetComponent<ChangeScene>().NextScene(6);
            } else {
                myGameObject.GetComponent<ChangeScene>().NextScene(1);
            }
        }                                                          
    }
}
