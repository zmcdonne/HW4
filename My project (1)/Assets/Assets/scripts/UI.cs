using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
[SerializeField] private TMP_Text pointsText;

private void Start()
    {
        if(Gamecontroller.Instance !=null)
        {
            Gamecontroller.Instance.OnScoreChange += UpdatePoints;
        }
    }

private void OnDestroy()
    {
        if (Gamecontroller.Instance !=null)
        {
            Gamecontroller.Instance.OnScoreChange -=UpdatePoints;
        }
    }
public void UpdatePoints (int points)
{
    pointsText.text = points.ToString();
}
}
