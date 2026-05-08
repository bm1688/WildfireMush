using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector2 _movement;

    [SerializeField] private float _speed;
    [SerializeField] private float _moveX;
    public float MoveX { get { return _moveX; } }
    [SerializeField] private float _moveY;
    public float MoveY { get { return _moveY; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = Input.GetAxisRaw("Horizontal");
        _moveY = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(_moveX, _moveY).normalized;

        _rb.velocity = _movement* _speed;
    }
    public void SetSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    
}
