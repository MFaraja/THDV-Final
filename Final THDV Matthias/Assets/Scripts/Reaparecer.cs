using System.Collections;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public GameObject objetoPrefab; // Prefab del objeto que se destruye y reaparece
    public float tiempoReaparicionMin = 5f; // Tiempo m�nimo de reaparici�n
    public float tiempoReaparicionMax = 15f; // Tiempo m�ximo de reaparici�n

    private void OnDestroy()
    {
        // Inicia la rutina para reactivar el objeto despu�s de un tiempo aleatorio
        StartCoroutine(ReaparecerObjeto());
    }

    private IEnumerator ReaparecerObjeto()
    {
        // Espera un tiempo aleatorio entre el m�nimo y m�ximo especificado
        float tiempoEspera = UnityEngine.Random.Range(tiempoReaparicionMin, tiempoReaparicionMax);
        yield return new WaitForSeconds(tiempoEspera);

        // Verifica si el objeto original ya no existe en la escena
        if (objetoPrefab != null)
        {
            // Instancia el objeto en la posici�n original
            Instantiate(objetoPrefab, transform.position, transform.rotation);
        }
    }
}
