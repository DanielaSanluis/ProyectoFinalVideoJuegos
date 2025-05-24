using UnityEngine;
using System.Collections.Generic;

public class SpawnerCompanero : MonoBehaviour
{
    public GameObject[] personajesEnEscena; // Los 4 personajes
    private int personajePrincipalIndex;
    private int companeroIndex;

    void Start()
    {
        // Recuperar el personaje seleccionado en la escena anterior
        personajePrincipalIndex = PlayerPrefs.GetInt("personajeSeleccionado", -1);

        if (personajePrincipalIndex == -1)
        {
            Debug.LogWarning("No se encontr� un personaje principal seleccionado.");
            return;
        }

        // Asegurarse de que est� activado el personaje principal
        personajesEnEscena[personajePrincipalIndex].SetActive(true);

        // Obtener los �ndices para el compa�ero
        List<int> opcionesCompanero = new List<int>();

        for (int i = 0; i < personajesEnEscena.Length; i++)
        {
            if (i != personajePrincipalIndex)
                opcionesCompanero.Add(i);
        }

        // Elegir uno aleatorio
        companeroIndex = opcionesCompanero[Random.Range(0, opcionesCompanero.Count)];

        // Activar el compa�ero
        personajesEnEscena[companeroIndex].SetActive(true);

        Debug.Log("Compa�ero activado: " + personajesEnEscena[companeroIndex].name);
    }
}
