using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageScript : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private int _damage;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            target.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}
