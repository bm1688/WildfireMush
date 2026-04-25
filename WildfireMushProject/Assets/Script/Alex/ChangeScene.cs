using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] public string _sceneName;
    public void NextScene()
    {
        Debug.Log($"Loaded {_sceneName} scene");
        SceneManager.LoadScene(_sceneName);
    }
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Debug.Log("Reset");
    }
    //public void GameOver()
    //{
    //    Debug.Log("Player died! Loading GameOver scene");
    //    SceneManager.LoadScene("GameOver");
    //}
}
