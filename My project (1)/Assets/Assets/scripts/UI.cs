using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsText;

    private void Start()
    {
        Gamecontroller.Instance.Player.PointsChanged += HandlePointsChanged;
    }

    private void HandlePointsChanged(int points)
    {
        pointsText.text = points.ToString();
    }
}
