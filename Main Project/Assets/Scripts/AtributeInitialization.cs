// using System;
using UnityEngine;
using System.Data;
// using Mono.Data.Sqlite;
// using System.IO;
using UnityEngine.UI;

public class AtributeInitialization : MonoBehaviour // инициализация 4 показателей
{
    public AudioSource sceneAudioSource; // звуковой эффект открытия сцены
    public int delay = 4; // задержка воспроизведения звукового эффекта, 4 сек.(не сработало)
    public Text show_current_day; // текстовое поле с номером текущего дня
    public Text show_current_health; // текстовое поле для значения "Здоровье"
    public Text show_current_progress; // текстовое поле для значения "Знания"
    public Text show_current_money; // текстовое поле для значения "Деньги"
    public Text show_current_mental; // текстовое поле для значения "Ментальное здоровье"
    public Button button_mental; // кнопка перехода к вопросу на тему "ментальное здоровье"
    public Button button_health; // кнопка перехода к вопросу на тему "физическое здоровье"
    public Button button_progress; // кнопка перехода к вопросу на тему "прогресс"
    public Button button_money; // кнопка перехода к вопросу на тему "деньги"

    public void Start()
    {
        // выборка параметров игрока из таблицы "Player"
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Player WHERE ID_player = 1;");
        // получаем текущие значения параметров
        int current_day = int.Parse(questionData.Rows[0][1].ToString());
        int current_mental = int.Parse(questionData.Rows[0][2].ToString());
        int current_health = int.Parse(questionData.Rows[0][3].ToString());
        int current_progress = int.Parse(questionData.Rows[0][4].ToString());
        int current_money = int.Parse(questionData.Rows[0][5].ToString());

        // если имеются кнопки перехода к вопросу выполнить дейсвтия
        if (button_mental != null || button_health != null || 
            button_progress != null || button_money != null)
        {
            // получить данные о заблакированных параметрах
            int block_mental = int.Parse(questionData.Rows[0][6].ToString());
            int block_health = int.Parse(questionData.Rows[0][7].ToString());
            int block_progress = int.Parse(questionData.Rows[0][8].ToString());
            int block_money = int.Parse(questionData.Rows[0][9].ToString());

            // заблокировать кнопку в соотвествии с данными
            if (block_mental == 1)
            {
                button_mental.interactable = false;
            }
            if (block_health == 1)
            {
                button_health.interactable = false;
            }
            if (block_progress == 1)
            {
                button_progress.interactable = false;
            }
            if (block_money == 1)
            {
                button_money.interactable = false;
            }
        }
        
        // показать текущие значения параметров
        show_current_day.text = current_day.ToString();
        show_current_mental.text = current_mental.ToString();
        show_current_health.text = current_health.ToString();
        show_current_progress.text = current_progress.ToString();
        show_current_money.text = current_money.ToString();

        // вопроизведение звукового эффекта с задержкой
        sceneAudioSource.PlayDelayed(delay);
    }

}
