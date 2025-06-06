using UnityEngine;

public class spawnPersoanje : MonoBehaviour
{
    public GameObject[] personajesDisponibles;
    public Transform puntoSpawn;

    void Start()
    {
        string nombrePersonaje = PlayerPrefs.GetString("personajeSeleccionado", "");

        if (string.IsNullOrEmpty(nombrePersonaje))
        {
            Debug.LogWarning("No se encontró personaje seleccionado.");
            return;
        }

        //Desactiva todos primero
        foreach (GameObject personaje in personajesDisponibles)
        {
            personaje.SetActive(false);
        }


        // Activa solo el que coincide
        foreach (GameObject personaje in personajesDisponibles)
        {
            if (personaje.name.Trim().ToLower() == nombrePersonaje.Trim().ToLower())
            {
                personaje.SetActive(true);
                personaje.transform.position = puntoSpawn.position;
                personaje.transform.rotation = puntoSpawn.rotation;
                DatosGlobales.personajeElegido = personaje;

                break;
            }
        }
    }
}
