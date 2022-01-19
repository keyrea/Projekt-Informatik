// using System.Collections;
// using System.Collections.Generic;
// using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // public AudioSource audioSource;
    // public AudioClip clip;
    // public float volume=0.5f;
    // public float delay=0.5f;
    // float m_LastPressTime;
    // float m_PressDelay = 0.001f;

    // Метод для перехода к следующей сцене. Аргумент _sceneNumber - номер сцены. 
    // Сцены и их номера можно найти в Build Settings
    public void NextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    // Метод для перехода к следующей сцене. Устанаваилвает значения параметров игрока по умолчанию
    public void NextSceneAndToDefault(int _sceneNumber)
    {
        string result = MyDataBase.ExecuteQueryWithAnswer("UPDATE Player " +
                                "SET day = 1," +
                                "current_mental = 5," +
                                "current_health = 5," +
                                "current_progress = 5," +
                                "current_money = 5," +
                                "block_mental = 0," +
                                "block_health = 0," +
                                "block_progress = 0," +
                                "block_money = 0 " +
                                "WHERE ID_player = 1;");
        SceneManager.LoadScene(_sceneNumber);
    }
}
