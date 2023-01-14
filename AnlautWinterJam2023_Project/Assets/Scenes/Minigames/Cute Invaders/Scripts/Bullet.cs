using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private enum Directions
    {
        Up,
        Down
    }

    [SerializeField] private Directions _direction = Directions.Up;
    [SerializeField] private float _bulletSpeed = 0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();    
    }


    private void OnDisable()
    {
        StopMove();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            Move(_direction == Directions.Up ? 1 : -1);
        }
    }

    private void Move(int direction)
    {
        _rigidbody.velocity = new Vector2(0f, direction * _bulletSpeed);
    }

    private void StopMove()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
