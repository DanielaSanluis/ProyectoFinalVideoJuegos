using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar la escena

public class seleccionarPersonaje : MonoBehaviour
{
    //public string nombrePersonaje; //cuando quiera seleccionarlo desde su nombre
    public int personajeIndex; // del 0 al 3 seleccionarlo desde el indice

    public void Seleccionar()
    {
        //seleccionarlo desde el indice
        PlayerPrefs.SetInt("personajeSeleccionado", personajeIndex);
        Debug.Log("Personaje seleccionado: " + personajeIndex);
        SceneManager.LoadScene("Instrucciones");

        /* // para cuando se quiera seleccionar desde su nombre en vez del indice
        PlayerPrefs.SetString("personajeSeleccionado", nombrePersonaje);
        Debug.Log("Personaje seleccionado: " + nombrePersonaje); 
        SceneManager.LoadScene("Instrucciones"); //escena instrucciones
        */
    }

    public void Continuar()
    {
        SceneManager.LoadScene("escena2"); // Escena inicial nivel1
    }
}


