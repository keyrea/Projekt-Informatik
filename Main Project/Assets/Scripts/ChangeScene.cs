using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void NextScene(int _sceneNumber) // Метод для перехода к следующей сцене. Аргумент _sceneNumber - номер сцены. Сцены и их номера можно найти в Build Settings
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void NextSceneAndToDefault(int _sceneNumber) // Метод для перехода к следующей сцене. Устанаваилвает значения параметров по умолчанию
    {
        string result = MyDataBase.ExecuteQueryWithAnswer("UPDATE Player " + 
                                "SET day = 1," + 
                                "current_mental = 5," + 
                                "current_health = 5," + 
                                "current_progress = 5," + 
                                "current_money = 5 " + 
                                "WHERE ID_player = 1;");
        SceneManager.LoadScene(_sceneNumber);
    }

}
