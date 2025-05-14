using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class prefs : MonoBehaviour
{
    [HideInInspector]
    public int totalRobotsEnEscena = 0;
    public TMP_Text balas;
    public TMP_Text ContadorVidas;
    public TMP_Text contadorRobots;

    public GameObject panelGameOver;//Panel para mensaje de "Game Over"
    public GameObject panelSiguienteNivel; //panel para pasar al siguiente nivel

    private int robotsDestruidos = 0;
    private int vidas = 3;
    
    void Start()
    {
        vidas = 3;
        ContadorVidas.text = vidas.ToString();

        robotsDestruidos = 0;
        contadorRobots.text = "0";
    }

    private void Awake()
    {
        loadData();
    }

    public void saveData()
    {
        PlayerPrefs.SetInt("balas", int.Parse(balas.text));
    }

    public int loadData()
    {
        int puntos = PlayerPrefs.GetInt("balas");
        balas.text = puntos.ToString();
        return puntos;
    }

    public void erraseData()
    {
        PlayerPrefs.DeleteKey("balas");
        balas.text = "0";
    }

    public void SumarRobotDestruido()
    {
        robotsDestruidos++;
        contadorRobots.text = robotsDestruidos.ToString();

        if (robotsDestruidos >= totalRobotsEnEscena)
        {
            MostrarPanelSiguienteNivel();
        }
    }

    public void RestarVida()
    {
        vidas = Mathf.Max(vidas - 1, 0);
        ContadorVidas.text = vidas.ToString();
        PlayerPrefs.SetInt("vidas", vidas);

        if (vidas <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        if (panelGameOver != null)
            panelGameOver.SetActive(true);
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void MostrarPanelSiguienteNivel()
    {
        Time.timeScale = 0f;
        if (panelSiguienteNivel != null)
            panelSiguienteNivel.SetActive(true);
    }

    public void RegistrarRobot()
    {
        totalRobotsEnEscena++;
    }
}

