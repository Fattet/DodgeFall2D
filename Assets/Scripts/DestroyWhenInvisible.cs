using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    private Camera mainCamera;

    public void Initialize(Camera camera)
    {
        mainCamera = camera;
    }

    private void Update()
    {
        if (IsOutsideScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutsideScreen()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Comprueba si la posici�n del objeto est� fuera de los l�mites de la pantalla
        return (viewportPosition.x < 0f || viewportPosition.x > 1f || viewportPosition.y < 0f || viewportPosition.y > 1f);
    }
}
