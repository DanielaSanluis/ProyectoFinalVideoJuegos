using UnityEngine;
using System.Collections.Generic;

public class managerCompañero : MonoBehaviour
{
    public GameObject[] duplicadosCompañeros; // ← KaelDuplicado, NoahDuplicado, etc.
    public Transform puntoAparicionCompañero;
    //private GameObject compañeroActivo;
    private bool compañeroActivado = false;

    // Este método será llamado desde el cristal morado
    public void ActivarCompañeroAleatorio()
    {
        if (compañeroActivado) return;

        // Obtener nombre del personaje principal seleccionado
        string nombrePrincipal = PlayerPrefs.GetString("personajeSeleccionado", "Kael"); // valor por defecto


        // Lista filtrada que excluye al duplicado del personaje principal
        List<GameObject> duplicadosDisponibles = new List<GameObject>();

        foreach (GameObject duplicado in duplicadosCompañeros)
        {
            if (!duplicado.name.StartsWith(nombrePrincipal)) // Evita, por ejemplo, "NoahDuplicado" si elegiste "Noah"
            {
                duplicadosDisponibles.Add(duplicado);
            }
        }

        if (duplicadosCompañeros.Length == 0)
        {
            Debug.LogWarning("No hay duplicados de compañeros asignados.");
            return;
        }


        // Elegir uno al azar de los duplicados disponibles
        GameObject compañeroElegido = duplicadosDisponibles[Random.Range(0, duplicadosDisponibles.Count)];

        // Activarlo y colocarlo en la posición deseada
        compañeroElegido.SetActive(true);
        compañeroElegido.transform.position = puntoAparicionCompañero.position;
        compañeroElegido.transform.rotation = puntoAparicionCompañero.rotation;

        compañeroActivado = true;

        /*
        int indice = Random.Range(0, duplicadosCompañeros.Length);
        compañeroActivo = duplicadosCompañeros[indice];

        if (compañeroActivo.tag == "Player")
        {
            compañeroActivo.tag = "Untagged";
        }

        compañeroActivo.SetActive(true);

        if (puntoAparicionCompañero != null)
        {
            compañeroActivo.transform.position = puntoAparicionCompañero.position;
        }

        Debug.Log("Compañero activado: " + compañeroActivo.name);
        */
    }
}
