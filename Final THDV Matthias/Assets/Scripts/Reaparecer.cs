using System.Collections;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab del objeto que se destruye y reaparece
    public float tiempoReaparicionMin = 5f; // Tiempo mínimo de reaparición
    public float tiempoReaparicionMax = 15f; // Tiempo máximo de reaparición

    private void OnDestroy()
    {
        // Inicia la rutina para reactivar el objeto después de un tiempo aleatorio
        StartCoroutine(ReaparecerObjeto());
    }

    private IEnumerator ReaparecerObjeto()
    {
        // Espera un tiempo aleatorio entre el mínimo y máximo especificado
        float tiempoEspera = UnityEngine.Random.Range(tiempoReaparicionMin, tiempoReaparicionMax);
        yield return new WaitForSeconds(tiempoEspera);

        // Verifica si el objeto original ya no existe en la escena
        if (objetoPrefab != null)
        {
            // Instancia el objeto en la posición original
            Instantiate(objetoPrefab, transform.position, transform.rotation);
        }
    }
}
