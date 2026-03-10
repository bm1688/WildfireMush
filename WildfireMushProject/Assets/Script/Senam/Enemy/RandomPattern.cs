using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPattern : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 velocity;
    private Rigidbody _rb;
    private Collider2D _collider;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider2D>();
        position = transform.position;
        velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * speed;
    }
    private void Update()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
            velocity += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        }
        else if (collision.gameObject.GetComponent<SimpleTest>())
        {
            Debug.Log("Game Over by random");
            //Time.timeScale = 0f;
        }
    }
}
