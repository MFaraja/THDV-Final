using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 3f; // Velocidad de movimiento del enemigo
    public string tagJugador = "Player"; // Tag del jugador para detectar al jugador
    public Transform spawnPoint; // Referencia al punto de spawn

    private Transform jugador; // Transform del jugador

    void Start()
    {
        // Buscar el jugador en la escena por su tag
        jugador = GameObject.FindGameObjectWithTag(tagJugador)?.transform;

        if (jugador == null)
        {
            UnityEngine.Debug.LogError("No se encontró el jugador en la escena.");
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccion = (jugador.position - transform.position).normalized;

            // Mover al enemigo hacia el jugador
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con el jugador
        if (collision.gameObject.CompareTag(tagJugador))
        {
            // Mover al jugador al punto de spawn
            if (spawnPoint != null)
            {
                collision.gameObject.transform.position = spawnPoint.position;
                UnityEngine.Debug.Log("¡El jugador fue movido al punto de spawn!");
            }
            else
            {
                UnityEngine.Debug.LogError("No se ha asignado un punto de spawn en el Enemigo.");
            }
        }
    }
}
