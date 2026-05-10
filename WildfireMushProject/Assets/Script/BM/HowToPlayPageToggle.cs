using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayPageToggle : MonoBehaviour
{
    [SerializeField] private List<GameObject> _howToPlayPanel = new List<GameObject>();

    [SerializeField] private int _toggleValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        _toggleValue = 0;

        ShowPanel(_toggleValue);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Toggle();
        }

        
    }
    private void Toggle()
    {
        _toggleValue += 1;

        if (_toggleValue >= _howToPlayPanel.Count)
        {
            _toggleValue = 0;
        }

        ShowPanel(_toggleValue);
    }

    private void ShowPanel(int panelIndex)
    {
        for (int i = 0; i < _howToPlayPanel.Count; i++)
        {
            _howToPlayPanel[i].SetActive(false);
        }

        _howToPlayPanel[panelIndex].SetActive(true);



    }
}
