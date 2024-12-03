using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    void Start()
    {
        // Bloquear el cursor en la pantalla del juego (opcional, solo si quieres bloquearlo).
        Cursor.lockState = CursorLockMode.Locked;

        // Asegurar que la cámara esté mirando siempre hacia abajo.
        transform.rotation = Quaternion.Euler(90, 0, 0);

        // Desactivar cualquier componente que permita rotar la cámara.
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

    void Update()
    {
        // No permitimos que la cámara rote de ninguna forma.
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
