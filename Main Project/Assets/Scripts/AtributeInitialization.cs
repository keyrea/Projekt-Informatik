using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtributeInitialization : MonoBehaviour // инициализация 4 показателей
{
    private int health = 100; // инициализация первоначального значения "Здоровье"
    private int study = 100; // инициализация первоначального значения "Знания"
    private float money = 1000.00f; // инициализация первоначального значения "Деньги"
    private float time = 100.00f; // инициализация первоначального значения "Время"

    public Text ShowHealth; // текстовое поле для значения "Здоровье"
    public Text ShowStudy; // текстовое поле для значения "Знания"
    public Text ShowMoney; // текстовое поле для значения "Деньги"
    public Text ShowTime; // текстовое поле для значения "Время"

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

    public void Awake() // при запуске сцены сразу должны отобразиться первоначальные значения 4 показателей
    {
        ShowHealth.text = Health.ToString() + " %";
        ShowMoney.text = Money.ToString() + " EUR";
        ShowStudy.text = Study.ToString();
        ShowTime.text = Time.ToString();
    }
}
