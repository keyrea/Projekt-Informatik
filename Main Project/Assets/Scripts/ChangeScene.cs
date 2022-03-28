using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Method for moving to the next scene. The _sceneNumber argument is the scene number.
    // Scenes and their numbers can be found in Build Settings
    public void NextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    // Method for moving to the next scene. Sets player options to default values
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
