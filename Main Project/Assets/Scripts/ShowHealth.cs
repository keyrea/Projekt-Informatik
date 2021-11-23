using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowHealth : HealthChange
{
    public Text showHealth;

    private void Awake()
    {
        HealthLevel healthLevel = new HealthLevel();
        showHealth.text = healthLevel.health.ToString() + " %";
    }
    
}

