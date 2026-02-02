using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
[SerializeField] private Rigidbody2D _rigidbody;
[SerializeField] private float _jump = 5f;

private bool _isGrounded = true;


void Update()
{
  if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
_rigidbody.linearVelocity = Vector2.up * _jump;
        }
    
}
}

