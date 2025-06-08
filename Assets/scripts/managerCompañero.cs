using UnityEngine;
using UnityEngine.SceneManagement;

public class managerCompañero : MonoBehaviour
{
    public GameObject[] personajes; // Todos los personajes en la escena
    public GameObject cristalMorado;
    public float distanciaAparicion = 2f; // distancia desde el jugador donde aparecerá el compañero

    private bool companeroActivado = false;

    void Update()
    {
        // Asegurarse que solo ocurra en Nivel5 y que el cristal ya fue tocado (destruido)
        if (!companeroActivado &&
            SceneManager.GetActiveScene().name == "Nivel5" &&
            cristalMorado == null)
        {
            ActivarCompanero();
            companeroActivado = true;
        }
    }

    void ActivarCompanero()
    {
        string nombreSeleccionado = PlayerPrefs.GetString("personajeSeleccionado", "");

        GameObject personajePrincipal = null;
        var candidatos = new System.Collections.Generic.List<GameObject>();

        // Identifica al personaje principal y los posibles compañeros
        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == nombreSeleccionado)
            {
                personajePrincipal = personaje;
            }
            else
            {
                candidatos.Add(personaje);
            }
        }

        if (personajePrincipal == null || candidatos.Count == 0)
        {
            Debug.LogWarning("No se encontró el personaje principal o no hay candidatos.");
            return;
        }

        // Selecciona compañero al azar
        GameObject companero = candidatos[Random.Range(0, candidatos.Count)];

        // Aparece cerca del jugador
        Vector3 offset = new Vector3(1.5f, 0, 1.5f);
        companero.transform.position = personajePrincipal.transform.position + offset;

        companero.SetActive(true);

        Debug.Log("Compañero activado: " + companero.name);
    }
}
