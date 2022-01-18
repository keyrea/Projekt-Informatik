using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.UI;

public class AtributeInitialization : MonoBehaviour // инициализация 4 показателей
{
    public AudioSource audioSource;
    public int delay = 4;
    public Text show_current_day;
    public Text show_current_health; // текстовое поле для значения "Здоровье"
    public Text show_current_progress; // текстовое поле для значения "Знания"
    public Text show_current_money; // текстовое поле для значения "Деньги"
    public Text show_current_mental; // текстовое поле для значения "Ментальное здоровье"
    public Button button_mental;
    public Button button_health;
    public Button button_progress;
    public Button button_money;

    public void Start()
    {
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Player WHERE ID_player = 1;");
        // Получаем текст вопроса
        int current_day = int.Parse(questionData.Rows[0][1].ToString());
        int current_mental = int.Parse(questionData.Rows[0][2].ToString());
        int current_health = int.Parse(questionData.Rows[0][3].ToString());
        int current_progress = int.Parse(questionData.Rows[0][4].ToString());
        int current_money = int.Parse(questionData.Rows[0][5].ToString());

        if (button_mental != null || button_health != null || button_progress != null || button_money != null){
            int block_mental = int.Parse(questionData.Rows[0][6].ToString());
            int block_health = int.Parse(questionData.Rows[0][7].ToString());
            int block_progress = int.Parse(questionData.Rows[0][8].ToString());
            int block_money= int.Parse(questionData.Rows[0][9].ToString());

            if (block_mental == 1){
                button_mental.interactable = false;
            }
            if (block_health == 1){
                button_health.interactable = false;
            }
            if (block_progress == 1){
                button_progress.interactable = false;
            }
            if (block_money == 1){
                button_money.interactable = false;
            }
        }

        show_current_day.text = current_day.ToString();
        show_current_mental.text = current_mental.ToString();
        show_current_health.text = current_health.ToString();
        show_current_progress.text = current_progress.ToString();
        show_current_money.text = current_money.ToString();


        audioSource.PlayDelayed(delay);
    }

}
