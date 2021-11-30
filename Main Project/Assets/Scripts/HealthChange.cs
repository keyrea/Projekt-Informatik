using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthChange : HealthLevel
{
    public Text showChangeHealth;
    private int healthPoints = 5;

    public void HealthMinus()
    {
        int actH = Health;
        actH = actH - healthPoints;
        showChangeHealth.text = actH.ToString() + " %";
    }

}


  