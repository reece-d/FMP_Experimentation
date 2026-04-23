using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    private bool _fireContinuously;

     void Update()
    {
        if (_fireContinuously)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject Bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rigidbody = Bullet.GetComponent<Rigidbody2D>();

        rigidbody.linearVelocity = _bulletSpeed * transform.up;
    }

    private void Onfire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;
    }
}
