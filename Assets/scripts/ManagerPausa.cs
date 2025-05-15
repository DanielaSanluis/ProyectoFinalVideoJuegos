using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPausa : MonoBehaviour
{
    public GameObject pausa;
    public bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
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
            Time.timeScale = 0; //pausar el juego
            //isPaused = !isPaused;
            isPaused = true;
        }
        else
        {
            pausa.SetActive(false);
            //pauseGame();
            Time.timeScale = 1; //reanudar el juego
            isPaused = false;
        }
    }

    public void regresarMenu()
    {
        //Recibe el indice de la escena
        SceneManager.LoadScene(0); //sceneMenu
        Time.timeScale = 1;
    }
    public void personajes()
    {
        //Recibe el indice de la escena
        SceneManager.LoadScene(1); //Personajes (seleccíon de ellos)
    }
    public void iniciarJuego()
    {
        //Recibe el indice de la escena
        SceneManager.LoadScene(2); //escena2
    }
    public void nivel2()
    {
        //Recibe el indice de la escena
        SceneManager.LoadScene(4); //nivel2
        Time.timeScale = 1;
    }

    public void salir()
    {
        //Recibe el indice de la escena
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
        //Recibe el indice de la escena
        SceneManager.LoadScene(5); //nivel3
        Time.timeScale = 1;
    }

    public void nivel1()
    {
        //Recibe el indice de la escena
        SceneManager.LoadScene(2); //nivel1
        Time.timeScale = 1;
    }
}
