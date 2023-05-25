using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 1f;
    public float spawnRangeXMin = -5f;
    public float spawnRangeXMax = 5f;
    public float objectSpeed = 5f;
    public float spawnOriginY = 0f; // Valor num�rico para el origen Y

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    private void SpawnObject()
    {
        // Generar un �ndice aleatorio para seleccionar un objeto prefabricado
        int prefabIndex = Random.Range(0, objectPrefabs.Length);

        // Calcular una posici�n aleatoria dentro del rango especificado, utilizando el spawnOriginY
        float spawnPositionX = Random.Range(spawnRangeXMin, spawnRangeXMax);
        Vector3 spawnPosition = new Vector3(spawnPositionX, spawnOriginY, 0f);

        // Instanciar el objeto y establecer su posici�n y velocidad
        GameObject newObject = Instantiate(objectPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
        Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.up * objectSpeed;

        // A�adir el script DestroyWhenInvisible al objeto generado
        DestroyWhenInvisible destroyScript = newObject.AddComponent<DestroyWhenInvisible>();
        destroyScript.Initialize(Camera.main);
    }
}
