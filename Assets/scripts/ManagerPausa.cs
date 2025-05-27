using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPausa : MonoBehaviour
{
    public GameObject pausa;
    public bool isPaused;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (!isPaused)
        {
            pausa.SetActive(true);
            Time.timeScale = 0; 
            isPaused = true;
        }
        else
        {
            pausa.SetActive(false);
            Time.timeScale = 1; //reanudar el juego
            isPaused = false;
        }
    }

    public void regresarMenu()
    {
        SceneManager.LoadScene(0); //sceneMenu
        Time.timeScale = 1;
    }
    public void personajes()
    {
        SceneManager.LoadScene(1); //Personajes (seleccíon de ellos)
    }
    public void iniciarJuego()
    {
        SceneManager.LoadScene(2); //escena2
    }
    public void nivel2()
    {
        SceneManager.LoadScene(4); //nivel2
        Time.timeScale = 1;
    }

    public void salir()
    {
        SceneManager.LoadScene(4); //nivel2
        Time.timeScale = 1;
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Continuar()
    {
        SceneManager.LoadScene("escena2");
    }

    public void nivel3()
    {
        SceneManager.LoadScene(5); //nivel3
        Time.timeScale = 1;
    }

    public void nivel1()
    {
        SceneManager.LoadScene(2); //nivel1
        Time.timeScale = 1;
    }
    public void nivel4()
    {
        SceneManager.LoadScene(6); //nivel4
        Time.timeScale = 1;
    }
}
