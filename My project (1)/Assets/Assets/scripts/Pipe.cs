using UnityEngine;

public class Pipe : MonoBehaviour
{
public float speed = 5f;
private Gamecontroller gameController;

    private void Start()
    {
       gameController = FindFirstObjectByType<Gamecontroller>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
   {
      
        if (other.CompareTag("Player"))
        {
            if (gameController !=null)
            {
                gameController.EndGame();
            }
        }
        
        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
