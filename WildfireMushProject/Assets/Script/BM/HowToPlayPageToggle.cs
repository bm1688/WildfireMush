using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayPageToggle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _howToPlayPanel = new List<GameObject>();

    [SerializeField] private int _toggleValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_toggleValue == 0)
            {
                Toggle();
                
            }
            else if (_toggleValue == 1)
            {
                Toggle();
            }
            else if (_toggleValue == 2)
            {
                Toggle();
            }
            else
            {
                Toggle();
                _toggleValue = 0;
            }
        }

        
    }
    private void Toggle()
    {
        _howToPlayPanel[_toggleValue].SetActive(true);
        _toggleValue += 1;
        if (_toggleValue == 0) { return; }
        _howToPlayPanel[_toggleValue - 1].SetActive(false);
    }
}
