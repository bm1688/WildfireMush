using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void NextScene()
    {
        Debug.Log("Loaded scene 2");
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
