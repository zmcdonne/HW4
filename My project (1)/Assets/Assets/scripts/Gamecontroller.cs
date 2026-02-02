using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gamecontroller : MonoBehaviour
{
[SerializeField] private GameObject PipePrefab;
[SerializeField] private UI ui;


private float spawnTimer = 0f;
// private int points = 0;
private void Update()
    {
       //timer 
        spawnTimer -= Time.deltaTime;

        // coin spawn
        if (spawnTimer <= 0)
        {
            SpawnPipe();

           
            spawnTimer = Random.Range(1f, 4f);
        }
    }

    private void SpawnPipe()
    {
        Camera cam = Camera.main;
        float y = cam.transform.position.y;
        float rightEdge = cam.transform.position.x + (cam.orthographicSize * cam.aspect);
        Vector3 position = new Vector3(rightEdge + 1f, y, 0f);

        Instantiate(PipePrefab, position, Quaternion.identity);
    }

   
//     public void UpdatePoints (int points)
// {
//     pointsText.text = points.ToString();
//         points++;
}

    

