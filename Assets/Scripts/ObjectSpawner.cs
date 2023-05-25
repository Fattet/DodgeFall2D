using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 2f;
    public float spawnForce = 5f;
    public float minX = -5f; // Valor mínimo del rango en el eje X
    public float maxX = 5f; // Valor máximo del rango en el eje X

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnObject();

            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);

        // Asignar el script DestroyWhenInvisible al prefab del objeto
        selectedPrefab.AddComponent<DestroyWhenInvisible>().Initialize(Camera.main);

        GameObject newObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * spawnForce;
    }
}
