using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    private Camera mainCamera;

    public void Initialize(Camera camera)
    {
        mainCamera = camera;
    }

    private void OnBecameInvisible()
    {
        if (mainCamera != null && !IsVisibleFromCamera(mainCamera))
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFromCamera(Camera camera)
    {
        if (GetComponent<Renderer>() == null)
        {
            // Si el objeto no tiene un componente Renderer, no es visible y se debe destruir
            return false;
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }
}
