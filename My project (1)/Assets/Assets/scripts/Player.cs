using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void IntDelegate(int points);
    public event IntDelegate PointsChanged;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jump = 5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;

    private int points = 0;
    private bool _isGrounded = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.linearVelocity = Vector2.up * _jump;
            audioSource.PlayOneShot(jumpSound);
        }
    }

    public void AddPoint()
    {
        points++;
        PointsChanged?.Invoke(points); 
    }

    public void HitPipe()
    {
        audioSource.PlayOneShot(deathSound);
        Gamecontroller.Instance.EndGame();
    }
}
