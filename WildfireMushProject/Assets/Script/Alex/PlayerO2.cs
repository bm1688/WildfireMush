using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2 : MonoBehaviour
{

    public float currentO2 = 100;
    public float maxO2 = 100;
    public OxygenTank oxygen;

    [Header("Rates")]
    [SerializeField] private float decreaseRate = 10f;
    [SerializeField] private float regenRate = 27f;

    private bool inSmoke = false;

    // Start is called before the first frame update
    void Start()
    {
        oxygen.SetMaxO2(maxO2);
        currentO2 = maxO2;
    }

    // Update is called once per frame
    void Update()
    {
        if (inSmoke)
        {
            O2Decrease(decreaseRate);
        }
        else
        {
            O2Regen(regenRate);
        }

        if (currentO2 > maxO2) currentO2 = maxO2;
        if (currentO2 < 0) currentO2 = 0;

        oxygen.SetO2(currentO2);
    }
    void O2Decrease(float rate)
    {
        currentO2 -= rate * Time.deltaTime;
    }

    void O2Regen(float rate)
    {
        currentO2 += rate * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Smoke"))
        {
            inSmoke = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Smoke"))
        {
            inSmoke = false;
        }
    }
}
