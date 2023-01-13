using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuteInvaders.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;

        [Range(0f, 5f)]
        [SerializeField] private float _moveSpeed = 0f; 

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                _rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * _moveSpeed, 0f);
            }

            if (Input.GetAxisRaw("Horizontal") == 0f)
            {
                _rigidBody.velocity = new Vector2(0f, 0f);
            }
        }
    }
}
