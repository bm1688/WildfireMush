using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChangeScene);
    }
    private void ChangeScene()
    {
        Debug.Log($"Changing scene to {_sceneName}");
        //SceneManager.LoadScene(_sceneName);
    }
}
