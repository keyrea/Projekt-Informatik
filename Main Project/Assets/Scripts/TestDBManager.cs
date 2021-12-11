using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class TestDBManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Получаем таблицу player
        DataTable playerdata = MyDataBase.GetTable("SELECT * FROM Player;");
        // Получаем id игрока
        int idPlayer = int.Parse(playerdata.Rows[0][0].ToString());
        // Получаем day игрока
        // string nickname = MyDataBase.ExecuteQueryWithAnswer($"SELECT day FROM Player WHERE id = {idPlayer};");
        Debug.Log($"Игрок {idPlayer} прожил {playerdata.Rows[0][1].ToString()} дней.");
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}