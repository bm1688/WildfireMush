using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float currentHealth = 50;
    public float maxHealth = 100;
    public OxygenBar oxygen;



    // Start is called before the first frame update
    void Start()
    {
        oxygen.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            TakeDamage(10f * Time.deltaTime);
        }
        else
        {
            TakeDamage(-27f  * Time.deltaTime);
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        oxygen.SetHealth(currentHealth);
    }
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
