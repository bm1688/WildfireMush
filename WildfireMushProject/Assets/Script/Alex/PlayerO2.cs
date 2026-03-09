using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2 : MonoBehaviour
{

    public float currentO2 = 100;
    public float maxO2 = 100;
    public OxygenTank oxygen;



    // Start is called before the first frame update
    void Start()
    {
        oxygen.SetMaxO2(maxO2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            O2Decrease(10f);
        }
        else
        {
            O2Regen(27f);
        }

        if (currentO2 > maxO2)
        {
            currentO2 = maxO2;
        }

        if (currentO2 < 0)
        {
            currentO2 = 0;
        }

        oxygen.SetO2(currentO2);
    }
    void O2Decrease(float damage)
    {
        currentO2 -= damage * Time.deltaTime;
    }
    void O2Regen(float damage)
    {
        currentO2 += damage * Time.deltaTime;
    }
}
