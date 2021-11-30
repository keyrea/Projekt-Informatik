using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthLevel : MonoBehaviour
{
    private int health=100;
    public Text ShowHealth;

    public int Health
    {
        get { return health; }
        set { health = 100; }
    }

    public void Awake()
    {
        ShowHealth.text = Health.ToString() + "%";
    }
}