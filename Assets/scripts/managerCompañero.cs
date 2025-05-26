using UnityEngine;

public class managerCompañero : MonoBehaviour
{
    public GameObject[] personajes; // los 4 persoanjes en la escena
    public GameObject cristalMorado;

    private bool companeroActivado = false;

    void Start()
    {
        // Desactiva todos excepto el personaje seleccionado al principio
        int indicePrincipal = PlayerPrefs.GetInt("personajeSeleccionado", 0);
        for (int i = 0; i < personajes.Length; i++)
        {
            personajes[i].SetActive(i == indicePrincipal);
        }
    }

    void Update()
    {
        if (!companeroActivado && cristalMorado == null) // el cristal ya fue destruido
        {
            ActivarCompanero();
            companeroActivado = true;
        }
    }

    void ActivarCompanero()
    {
        int indicePrincipal = PlayerPrefs.GetInt("personajeSeleccionado", 0);
        int[] candidatos = new int[3];
        int j = 0;

        // El compañero sera seleccionado de entre estos 3 persoanjes restantes
        for (int i = 0; i < 4; i++)
        {
            if (i != indicePrincipal)
            {
                candidatos[j++] = i;
            }
        }

        // Selecciona uno al azar
        int elegido = candidatos[Random.Range(0, 3)];
        personajes[elegido].SetActive(true);

        Debug.Log("Compañero activado: " + elegido);
    }
}
