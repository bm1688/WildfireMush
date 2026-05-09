using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerAimAndShoot _playerAimAndShoot;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Animator _playerAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerAimAndShoot.Shooting && _playerAimAndShoot.LookDir.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_playerAimAndShoot.Shooting && _playerAimAndShoot.LookDir.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (!_playerAimAndShoot.Shooting)
        {
            if (_playerMovement.MoveX > 0)
            {
                _playerAnimator.SetBool("IsRunning", true);
                _spriteRenderer.flipX = false;
            }
            else if (_playerMovement.MoveX < 0)
            {
                _playerAnimator.SetBool("IsRunning", true);
                _spriteRenderer.flipX = true;
            }
            else if (_playerMovement.MoveY != 0)
            {
                _playerAnimator.SetBool("IsRunning", true);
            }
            else
            {
                _playerAnimator.SetBool("IsRunning", false);
            }
        }
        

        if (_playerMovement.MoveX == 0 && _playerMovement.MoveY == 0)
        {

            if (_playerAimAndShoot.Shooting && _playerAimAndShoot.LookDir.x > 0)
            {
                _playerAnimator.SetBool("IsShooting", true);
                _playerAnimator.SetBool("IsRunning", false);
                _spriteRenderer.flipX = false;
            }
            else if (_playerAimAndShoot.Shooting && _playerAimAndShoot.LookDir.x < 0)
            {
                _playerAnimator.SetBool("IsShooting", true);
                _playerAnimator.SetBool("IsRunning", false);
                _spriteRenderer.flipX = true;
            }
            else
            {
                _playerAnimator.SetBool("IsShooting", false);
                _playerAnimator.SetBool("IsRunning", false );
            }
        }


    }
}
