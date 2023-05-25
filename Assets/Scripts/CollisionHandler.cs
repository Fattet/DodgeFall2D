using UnityEngine;

public class Skydiver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("ObjectSpawnerObject"))
    {
        Destroy(collision.gameObject);
    }
}
}
