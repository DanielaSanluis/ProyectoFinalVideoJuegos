using UnityEngine;

public class spawnPersonaje : MonoBehaviour
{
    public GameObject[] personajesDisponibles; // Personajes ya colocados en la escena
    public Transform puntoSpawn; // Punto donde deben posicionarse (opcional si ya están bien posicionados)

    void Start()
    {
        string nombrePersonaje = PlayerPrefs.GetString("personajeSeleccionado", "");
        //Debug.Log("Nombre de personaje leído: " + nombrePersonaje);

        if (string.IsNullOrEmpty(nombrePersonaje))
        {
            Debug.LogWarning("No se encontró personaje seleccionado.");
            return;
        }

        // Desactiva todos primero
        foreach (GameObject personaje in personajesDisponibles)
        {
            personaje.SetActive(false);
        }

        // Activa solo el que coincide
        foreach (GameObject personaje in personajesDisponibles)
        {
            //Debug.Log($"Comparando '{personaje.name}' con '{nombrePersonaje}'");

            if (personaje.name.Trim().ToLower() == nombrePersonaje.Trim().ToLower())
            {
                personaje.SetActive(true);
                personaje.transform.position = puntoSpawn.position;
                personaje.transform.rotation = puntoSpawn.rotation;
                //Debug.Log("Personaje activado: " + personaje.name);
                break;
            }
        }
    }

}
