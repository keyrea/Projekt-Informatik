using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtributeChangeAnswer1 : AtributeInitialization // изменение 4х показателей при нажатии кнопки "Answer1", наследование от Atributeinizialization
{
    private int healthPoints = -5; // на сколько изменится показатель "Здоровье"
    private int studyPoints = -20; // на сколько изменится показатель "Знания"
    private float moneyPoints = -60.00f; // на сколько изменится показатель "Деньги"
    private float timePoints = -10.00f; // на сколько изменится показатель "Время"

    private int actH; /* при нажатии кнопки изменённый показатель не менялся, пришлось ввести эту переменную, которая присваивает значение соответствующего
                       * показателся в теле метода Answer1. actH- actuall Health
                       */
    private int actS; // actuall Study
    private float actM; // actuall Money
    private float actTime; // actuall Time

    public Text ShowHealthChange;
    public Text ShowStudyChange;
    public Text ShowMoneyChange;
    public Text ShowTimeChange;

    public void Answer1() /* метод Answer1- при нажатии на него должны изменяться 4 показателя
                           *если один или несколько показателей не меняются, то им присвоится значение 0 при инициализации в начале скрипта.
                           */
    {
        actH = Health;
        actS = Study;
        actM = Money;
        actTime = Time;
        actH = actH + healthPoints; /* при инициализации переменной, которая изменяет значение одного из 4 показателей, присвается отрицательное или положительное
                                     * так что в выражениях, изменяющих значение показателя, присутствует всегда знак плюс вне зависимости от того, этот 
                                     * показатель должен уменьшатся или увеличиваться
                                     */
        actS = actS + studyPoints;
        actM = actM + moneyPoints;
        actTime = actTime + timePoints;
        ShowHealthChange.text = actH.ToString() + " %";
        ShowStudyChange.text = actS.ToString();
        ShowMoneyChange.text = actM.ToString() + " EUR";
        ShowTimeChange.text = actTime.ToString();
    }


}
