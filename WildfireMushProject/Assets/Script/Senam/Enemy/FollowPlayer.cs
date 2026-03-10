using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // This script makes the enemy follow the player
    [SerializeField] private Transform player; // Reference to the player's transform
    [SerializeField] private float speed = 3f; // Speed at which the enemy follows the player
    private Collider2D _collider;
    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;
            // Move the enemy towards the player
            transform.Translate(direction * speed * Time.deltaTime, Space.World);           
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SimpleTest>())
        {
            Debug.Log("Game Over by follow");
            //Time.timeScale = 0f;
        }
    }





}
