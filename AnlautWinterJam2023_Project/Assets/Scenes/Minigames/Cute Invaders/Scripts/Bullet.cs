using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    public class Bullet : MonoBehaviour
    {
        private enum Directions
        {
            Up,
            Down
        }

        [SerializeField] private Directions _direction = Directions.Up;
        [SerializeField] private float _bulletSpeed = 0f;
        [SerializeField] private float _bulletLifeTime = 0f;
        private float _currentBulletLifeTime;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _currentBulletLifeTime = _bulletLifeTime;
        }


        private void OnEnable()
        {
            _currentBulletLifeTime = _bulletLifeTime;
        }

        private void OnDisable()
        {
            StopMove();
        }

        private void Update()
        {
            Move(_direction == Directions.Up ? 1 : -1);
            Timer();
  
            if (_currentBulletLifeTime == 0)
            {
                gameObject.SetActive(false);
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

        private void Timer()
        {
            _currentBulletLifeTime = Mathf.Clamp(_currentBulletLifeTime - Time.deltaTime, 0, _bulletLifeTime);
        }

    }
}