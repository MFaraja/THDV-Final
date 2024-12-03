using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject jugadorPrefab; // Prefab del jugador

    void Start()
    {
        // Instanciar el jugador en la posici�n del spawn point
        if (jugadorPrefab != null)
        {
            Instantiate(jugadorPrefab, transform.position, transform.rotation);
        }
        else
        {
            UnityEngine.Debug.LogError("El prefab del jugador no est� asignado en el SpawnPoint.");
        }
    }
}
