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

    public GameObject[] robotsExtra; 
    private bool robotsExtraActivados = false;


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
        Debug.Log("robotsDestruidos = " + robotsDestruidos);

        int totalEsperado = totalRobotsEnEscena + robotsExtra.Length;
        Debug.Log($"Comparando: robotsDestruidos={robotsDestruidos} vs totalEsperado={totalEsperado}");

        if (robotsExtra.Length > 0)
        {
            if (!robotsExtraActivados && robotsDestruidos >= totalRobotsEnEscena)
            {
                Debug.Log("Activando robots extra...");
                ActivarRobotsExtra();
                return;
            }

            if (robotsExtraActivados && robotsDestruidos >= totalEsperado)
            {
                Debug.Log("Mostrando panel siguiente nivel...");
                MostrarPanelSiguienteNivel();
            }
        }
        else
        {
            // No hay robots extra, muestra el panel directamente
            if (robotsDestruidos >= totalRobotsEnEscena)
            {
                Debug.Log("Mostrando panel (no hay robots extra)...");
                MostrarPanelSiguienteNivel();
            }
        }
    }



    void ActivarRobotsExtra()
    {
        robotsExtraActivados = true;

        foreach (GameObject r in robotsExtra)
        {
            if (r != null)
            {
                r.SetActive(true);
            }
        }

        Debug.Log("�Robots extra activados!");
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
        Debug.Log(" MostrarPanelSiguienteNivel() llamado.");
        Time.timeScale = 0f;

        if (panelSiguienteNivel != null)
        {
            panelSiguienteNivel.SetActive(true);
            Debug.Log(" Panel activado correctamente.");
        }
        else
        {
            Debug.LogError(" panelSiguienteNivel no est� asignado.");
        }
    }


    public void RegistrarRobot()
    {
        totalRobotsEnEscena++;
    }
}

