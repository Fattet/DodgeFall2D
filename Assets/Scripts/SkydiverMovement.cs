using UnityEngine;

public class SkydiverMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMobile = false;

    private void Start()
    {
        // Verificar si el juego se est� ejecutando en un dispositivo m�vil
        isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (isMobile)
        {
            // Mover el Skydiver con el joystick virtual en dispositivos m�viles
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
        // Obtener el n�mero de toques en la pantalla
        int touchCount = Input.touchCount;

        if (touchCount > 0)
        {
            // Mover el Skydiver con el joystick virtual en el primer toque
            Touch touch = Input.GetTouch(0);

            // Obtener la posici�n del joystick virtual en relaci�n con la pantalla
            Vector2 touchPosition = touch.position;

            // Convertir la posici�n del joystick virtual a un valor entre -1 y 1 en cada eje
            float moveHorizontal = (touchPosition.x / Screen.width) * 2 - 1;
            float moveVertical = (touchPosition.y / Screen.height) * 2 - 1;

            // Calcular el movimiento del Skydiver
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

            // Aplicar el movimiento al transform del Skydiver
            transform.Translate(movement);
        }
    }
}
