using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void NextScene(int _sceneNumber) // Метод для перехода к следующей сцене
                                            // Аргумент _sceneNumber- номер сцены. Сцены и их номера можно найти в Build Settings
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
