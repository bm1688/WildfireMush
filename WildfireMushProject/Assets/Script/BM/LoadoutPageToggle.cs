using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutPageToggle : MonoBehaviour
{
    [SerializeField] private GameObject _loadoutUI;

    [SerializeField] private int _toggleValue = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && (_toggleValue == 0))
        {
            _toggleValue = 1;
            _loadoutUI.SetActive(true);
            Debug.Log("Open");
        }
        else if (Input.GetKeyDown(KeyCode.G) && (_toggleValue == 1))
        {
            _toggleValue = 0;
            _loadoutUI.SetActive(false);
            Debug.Log("Close");
        }
    }
}
