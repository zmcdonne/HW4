using UnityEngine;

public class ScoreAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointSound;

    private void Start()
    {
        Gamecontroller.Instance.Player.PointsChanged += PlayPointSound;
    }

    private void PlayPointSound(int points)
    {
        audioSource.PlayOneShot(pointSound);
    }
}
