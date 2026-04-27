using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class FireDamageScript : MonoBehaviour
{
    [SerializeField] private GameObject _fire;

    [SerializeField] private Collider2D _collider;

    [SerializeField] private int _damage;

    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _timeSinceLastDamage;
    [SerializeField] private float _damageInterval;

    [SerializeField] private bool hit;


    [SerializeField] private IDamageable  tree;

    // Update is called once per frame
    void Update()
    {

        _timeSinceLastDamage += Time.deltaTime;

        
       
        

        if (!hit) return;
        if (tree == null ) return;
        if (_timeSinceLastDamage < _damageInterval) return;
        tree.ApplyDamage(_damagePerSecond * _damageInterval);
        Debug.Log($"burning {tree}");
        _timeSinceLastDamage = 0;
        /*if (hit && tree != null)
        {
            Debug.Log("detected");
            if (_timeSinceLastDamage >= _damageInterval)
            {
                tree.ApplyDamage(_damagePerSecond * _damageInterval);
                Debug.Log($"burning {tree}");
                _timeSinceLastDamage = 0;
            }
        } change to guard clause*/





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            //_timeSinceLastDamage = 0;
            hit = true;
            Debug.Log("Entered hitbox");
            tree = target;
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            _timeSinceLastDamage += Time.deltaTime;
            Debug.Log("burning");
            if (_timeSinceLastDamage >= _damageInterval)
            {
                target.ApplyDamage(_damagePerSecond * _damageInterval);
                
                
            }

            
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            hit = false;
            
        }
    }
}
