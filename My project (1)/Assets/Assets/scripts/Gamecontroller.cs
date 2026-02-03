using UnityEngine;
using System;

public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller Instance;

    public event Action<int> OnScoreChange;

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float minY = -2f;
    [SerializeField] private float maxY = 2f;
    [SerializeField] private float spawnInterval = 2f;

    private float spawnTimer;
    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            float randomY = UnityEngine.Random.Range(minY, maxY);
            SpawnPipe(randomY);
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnPipe(float y)
    {
        Camera cam = Camera.main;
        float rightEdge = cam.transform.position.x + (cam.orthographicSize * cam.aspect);
        Vector3 position = new Vector3(rightEdge + 1f, y, 0f);

        Instantiate(pipePrefab, position, Quaternion.identity);
    }

    public void AddPoints()
    {
        score++;
        OnScoreChange?.Invoke(score); // 🔥 EVENT FIRED
    }
}
