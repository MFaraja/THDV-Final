using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar la escena

public class Bombas : MonoBehaviour
{
    public GameObject bombaPrefab; // Prefab de la bomba
    public float tiempoExplosion = 3f; // Tiempo para que la bomba explote
    public float radioExplosion = 5f; // Radio de la explosi�n
    private GameObject bombaActiva; // Referencia a la bomba activa

    void Update()
    {
        // Detectar la tecla E para colocar una bomba si no hay una activa
        if (Input.GetKeyDown(KeyCode.E) && bombaActiva == null)
        {
            ColocarBomba();
        }
    }

    private void ColocarBomba()
    {
        // Instancia una bomba en la posici�n actual del jugador
        Vector3 posicionBomba = transform.position;
        bombaActiva = Instantiate(bombaPrefab, posicionBomba, Quaternion.identity);

        // Inicia la rutina para la explosi�n de la bomba
        StartCoroutine(ExplotarBomba(bombaActiva));
    }

    private IEnumerator ExplotarBomba(GameObject bomba)
    {
        // Espera el tiempo de explosi�n
        yield return new WaitForSeconds(tiempoExplosion);

        // Detecta los objetos destruidos dentro del radio de explosi�n
        Collider[] objetosAfectados = Physics.OverlapSphere(bomba.transform.position, radioExplosion);

        foreach (Collider objeto in objetosAfectados)
        {
            if (objeto.CompareTag("Destruibles"))
            {
                // Desactiva el objeto en lugar de destruirlo
                objeto.gameObject.SetActive(false);

                // Inicia la coroutine para reaparecer el objeto con un tiempo de espera aleatorio
                StartCoroutine(ReaparecerObjeto(objeto.gameObject));
            }

            // Verifica si el jugador est� dentro del �rea de la explosi�n
            if (objeto.CompareTag("Player"))
            {
                // Reinicia la escena si el jugador est� dentro del �rea de la explosi�n
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // Destruye la bomba despu�s de la explosi�n
        Destroy(bomba);

        // Resetea la referencia de bomba activa
        bombaActiva = null;
    }

    private IEnumerator ReaparecerObjeto(GameObject objeto)
    {
        // Espera un tiempo aleatorio entre 5 y 10 segundos antes de reactivar el objeto usando UnityEngine.Random
        float tiempoEspera = UnityEngine.Random.Range(5f, 10f);
        yield return new WaitForSeconds(tiempoEspera);

        // Reactiva el objeto
        objeto.SetActive(true);
    }
}
