using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar la escena

public class seleccionarPersonaje : MonoBehaviour
{
    public string nombrePersonaje;

    public void Seleccionar()
    {
        PlayerPrefs.SetString("personajeSeleccionado", nombrePersonaje);
        Debug.Log("Personaje seleccionado: " + nombrePersonaje); 
        SceneManager.LoadScene("Instrucciones"); //escena instrucciones
    }

    public void Continuar()
    {
        SceneManager.LoadScene("escena2"); // Escena inicial nivel1
    }
}


