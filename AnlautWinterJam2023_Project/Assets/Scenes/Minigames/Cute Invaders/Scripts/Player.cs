using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;
        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                Move();
            }

            if (Input.GetAxisRaw("Horizontal") == 0f)
            {
                StopMove();
            }
        }

        #region Move

        private Vector3 refVel = Vector3.zero;

        [SerializeField] private float smoothValue = .2f;

        //[Range(0f, 5f)]
        [SerializeField] private float _moveSpeed = 0f;

        private void Move()
        {
            float horizontalAxis = Input.GetAxis("Horizontal");

            _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, new Vector3(horizontalAxis * _moveSpeed * Time.fixedDeltaTime, 0f, 0f), ref refVel, smoothValue);
        }

        private void StopMove()
        {

            _rigidBody.velocity = Vector3.SmoothDamp(_rigidBody.velocity, Vector3.zero, ref refVel, smoothValue);
        }

        #endregion

        #region Shoot
        private void Shoot()
        {

        }

        #endregion
    }
}