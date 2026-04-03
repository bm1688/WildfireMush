using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScript : MonoBehaviour
{
    private GameObject _instance;

    private GameObject Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
