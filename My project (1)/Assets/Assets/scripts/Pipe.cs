using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Gamecontroller.Instance.AddPoints();
            GetComponent<Collider2D>().enabled = false;
        }

        if (other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
