using UnityEngine;

public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller Instance { get; private set; }

    public Player Player { get; private set; }

    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private float spawnTimer = 0f;
    private bool _isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        Player = playerObj.GetComponent<Player>();
    }

    private void Update()
    {
        if (_isGameOver) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            float randomY = Random.Range(_minY, _maxY);
            SpawnPipe(randomY);
            spawnTimer = 1f;
        }
    }

    private void SpawnPipe(float y)
    {
        Camera cam = Camera.main;
        float rightEdge = cam.transform.position.x + (cam.orthographicSize * cam.aspect);
        Vector3 position = new Vector3(rightEdge + 1f, y, 0f);
        Instantiate(PipePrefab, position, Quaternion.identity);
    }

    public void EndGame()
    {
        _isGameOver = true;
        Time.timeScale = 0f;
    }
}
