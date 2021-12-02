using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributeChangeAnswer2 : AtributeChangeAnswer1 /* изменение 4х показателей при нажатии кнопки "Answer2", наследование от AtributeChangeAnswer1,
                                                            * чтобы не создавать снова переменные для текстового поля
                                                            */
{
    private int healthPoints = 0;
    private int studyPoints = 5;
    private float moneyPoints = 0.0f;
    private float timePoints = 1.0f;

    private int actH;
    private int actS;
    private float actM;
    private float actTime;

    public void Answer2()
    {
        actH = Health;
        actS = Study;
        actM = Money;
        actTime = Time;
        actH = actH + healthPoints;
        actS = actS + studyPoints;
        actM = actM + moneyPoints;
        actTime = actTime + timePoints;
        ShowHealthChange.text = actH.ToString() + " %";
        ShowStudyChange.text = actS.ToString();
        ShowMoneyChange.text = actM.ToString() + " EUR";
        ShowTimeChange.text = actTime.ToString();
    }


}
