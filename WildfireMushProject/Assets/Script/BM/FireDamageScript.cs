using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageScript : MonoBehaviour
{
    [SerializeField] GameObject _fire;
    [SerializeField] Collider2D _collider;
    [SerializeField] int _damage;

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
