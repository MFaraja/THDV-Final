using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    void Start()
    {
        // Bloquear el cursor en la pantalla del juego (opcional, solo si quieres bloquearlo).
        Cursor.lockState = CursorLockMode.Locked;

        // Asegurar que la cámara esté mirando siempre hacia abajo.
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
