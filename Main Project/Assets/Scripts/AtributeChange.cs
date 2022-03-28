// using System.Collections;
// using System.Collections.Generic;
// using Mono.Data.Sqlite;
// using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class AtributeChange : MonoBehaviour
{
    public GameObject sceneManager; // reference to the object responsible for the transition between scenes
    public Text get_question_category; // text field with question category
    public Text get_current_day; // text field with current day number
    public Text get_current_mental; // text field for the value "Mental health"
    public Text get_current_health; // text field for "Health" value
    public Text get_current_progress; // text field for value "Knowledge"
    public Text get_current_money; // text field for value "Money"

    public Text get_yes_mental; // text field for "Mental health" value of "yes" answer
    public Text get_yes_health; // text field for "Health" value of "yes" answer
    public Text get_yes_progress; // text field for "Knowledge" value of "yes" answer
    public Text get_yes_money; // text field for value "Money" answer "yes"

    public Text get_no_mental; // text field for "Mental health" value of answer "no"
    public Text get_no_health; // text field for "Health" value of answer "no"
    public Text get_no_progress; // text field for value "Knowledge" answer "no"
    public Text get_no_money; // text field for value "Money" answer "no"

    public void changeAtribute(string answer_type)// gets response type yes/no
    {
        // database query
        string result = "";
        // value to check for the occurrence of a random event
        bool event_was = false;
        // question category
        int question_type = int.Parse(get_question_category.text.ToString());

        // new current parameter values (by default, they store the old current values)
        int new_current_day = int.Parse(get_current_day.text.ToString());
        int new_current_mental = int.Parse(get_current_mental.text.ToString());
        int new_current_health = int.Parse(get_current_health.text.ToString());
        int new_current_progress = int.Parse(get_current_progress.text.ToString());
        int new_current_money = int.Parse(get_current_money.text.ToString());

        // parameter lock values
        int new_curent_block_mental = 0;
        int new_curent_block_health = 0;
        int new_curent_block_progress = 0;
        int new_curent_block_money = 0;

        // if the answer type is "yes" add to the current values ​​of the answer value "yes"
        if (answer_type == "yes")
        {
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental += int.Parse(get_yes_mental.text.ToString());
            new_current_health += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money += int.Parse(get_yes_money.text.ToString());
        }
        // if the answer type is "no", add the value of the answer "no" to the current values
        else if (answer_type == "no")
        {
            new_current_day = int.Parse(get_current_day.text.ToString()) + 1;
            new_current_mental += int.Parse(get_no_mental.text.ToString());
            new_current_health += int.Parse(get_no_health.text.ToString());
            new_current_progress += int.Parse(get_no_progress.text.ToString());
            new_current_money += int.Parse(get_no_money.text.ToString());
        }
        // if the response type is "ok" add to the current values the response values "ok"
        else if (answer_type == "ok")
        {
            new_current_day = int.Parse(get_current_day.text.ToString());
            new_current_mental += int.Parse(get_yes_mental.text.ToString());
            new_current_health += int.Parse(get_yes_health.text.ToString());
            new_current_progress += int.Parse(get_yes_progress.text.ToString());
            new_current_money += int.Parse(get_yes_money.text.ToString());
            // set random event occurrence checks to "true"(has already happened)
            event_was = true;
        }

        // if the current value has exceeded 10, then lower it to 10
        if (new_current_mental > 10) { new_current_mental = 10; }
        if (new_current_health > 10) { new_current_health = 10; }
        if (new_current_progress > 10) { new_current_progress = 10; }
        if (new_current_money > 10) { new_current_money = 10; }

        // lock option based on question category
        if (question_type == 1) { new_curent_block_mental = 1; }
        else if (question_type == 2) { new_curent_block_health = 1; }
        else if (question_type == 3) { new_curent_block_progress = 1; }
        else if (question_type == 4) { new_curent_block_money = 1; }

        // creating and sending a query to the database
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

        // if the current value has dropped to 0 or below, go to the results scene
        if (new_current_mental <= 0 || new_current_health <= 0 ||
            new_current_progress <= 0 || new_current_money <= 0)
        {
            sceneManager.GetComponent<ChangeScene>().NextScene(7);
        }
        // otherwise go to the question category selection menu or trigger a random event
        else
        {
            // random value of random event
            System.Random randomEventChance = new System.Random();
            int eventChance = randomEventChance.Next(0, 100);
            Debug.Log(eventChance);

            // 10% chance of a random event, if the random value matches, a random event is triggered
            if (event_was == false && eventChance >= 0 && eventChance <= 10)
            {
                sceneManager.GetComponent<ChangeScene>().NextScene(6);
            }
            // otherwise, the question category selection scene is launched
            else
            {
                sceneManager.GetComponent<ChangeScene>().NextScene(1);
            }
        }
    }
}
