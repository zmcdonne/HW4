using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
[SerializeField] private TMP_Text pointsText;

public void UpdatePoints (int points)
{
    pointsText.text = points.ToString();
}
}
