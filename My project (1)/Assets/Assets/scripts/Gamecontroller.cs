using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller Instance;
    public event Action<int> OnScoreChange;
[SerializeField] private GameObject PipePrefab;


[SerializeField] private float _minY = -2f;
[SerializeField] private float _maxY =2f;

private float spawnTimer = 0f;
 private int points = 0;
private void Awake() 
    {
    {
     
        spawnTimer -= Time.deltaTime;

    
        if (spawnTimer <= 0)
        {
           
            float randomY = Random.Range(_minY,_maxY);
             SpawnPipe(randomY);
              spawnTimer = Random.Range(1f, 1f);
        }
    }

    private void SpawnPipe(float y)
    {
        Camera cam = Camera.main;
        // float y = cam.transform.position.y;
        float rightEdge = cam.transform.position.x + (cam.orthographicSize * cam.aspect);
        Vector3 position = new Vector3(rightEdge + 1f, y, 0f);

        Instantiate(PipePrefab, position, Quaternion.identity);
    }

   
//     public void UpdatePoints (int points)
// {
//     pointsText.text = points.ToString();
//         points++;
}

    

