using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
[SerializeField] private Rigidbody2D _rigidbody;
[SerializeField] private float _jump = 5f;
[SerializeField] AudioSource audioSource;
[SerializeField] private AudioClip jumpSound;
[SerializeField] private AudioClip deathSound;

private bool _isDead = false;


void Update()
{
  if (_isDead) return;
  if (Input.GetKeyDown(KeyCode.Space))
        {
_rigidbody.linearVelocity = Vector2.up * _jump;

audioSource.PlayOneShot(jumpSound);
        }
    
}

    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject. CompareTag("Ground"))
                {
                        Die();
                }
    }
    private void Die()
        {
                _isDead = true;
                audioSource.PlayOneShot(deathSound);
                Time.timeScale = 0f;
        }
}

