using UnityEngine;

public class SkydiverMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMobile = false;

    private void Start()
    {
        // Verificar si el juego se está ejecutando en un dispositivo móvil
        isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (isMobile)
        {
            // Mover el Skydiver con el joystick virtual en dispositivos móviles
            HandleMobileMovement();
        }
        else
        {
            // Mover el Skydiver con las flechas en una PC
            HandlePCMovement();
        }
    }

    private void HandlePCMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento del Skydiver
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

        // Aplicar el movimiento al transform del Skydiver
        transform.Translate(movement);
    }

    private void HandleMobileMovement()
    {
        // Obtener el número de toques en la pantalla
        int touchCount = Input.touchCount;

        if (touchCount > 0)
        {
            // Mover el Skydiver con el joystick virtual en el primer toque
            Touch touch = Input.GetTouch(0);

            // Obtener la posición del joystick virtual en relación con la pantalla
            Vector2 touchPosition = touch.position;

            // Convertir la posición del joystick virtual a un valor entre -1 y 1 en cada eje
            float moveHorizontal = (touchPosition.x / Screen.width) * 2 - 1;
            float moveVertical = (touchPosition.y / Screen.height) * 2 - 1;

            // Calcular el movimiento del Skydiver
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

            // Aplicar el movimiento al transform del Skydiver
            transform.Translate(movement);
        }
    }
}
