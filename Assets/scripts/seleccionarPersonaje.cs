using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar la escena

public class seleccionarPersonaje : MonoBehaviour
{
    public string nombrePersonaje; // Poner en unity los nombres de los personajes

    public void Seleccionar()
    {
        PlayerPrefs.SetString("personajeSeleccionado", nombrePersonaje);
        Debug.Log("Personaje seleccionado: " + nombrePersonaje); // AGREGAR ESTO
        SceneManager.LoadScene("Instrucciones"); //escena inical nivel1
    }

    public void Continuar()
    {
        SceneManager.LoadScene("escena2");
    }
}


