using UnityEngine;

public class Pipe : MonoBehaviour
{
public float speed = 5f;
private Gamecontroller Gamecontroller;

    private void Start()
    {
        Gamecontroller = FindFirstObjectByType<Gamecontroller>();
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
   {
      
        if (other.tag == "Player")
        {
            // Gamecontroller.AddPoints();
            Destroy(gameObject);
        }
        
        if (other.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
