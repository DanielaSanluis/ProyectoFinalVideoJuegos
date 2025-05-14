using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class prefs : MonoBehaviour
{
    public TMP_Text balas;
    public TMP_Text ContadorVidas;
    public TMP_Text contadorRobots;
    public GameObject panelGameOver; // referencia al panel

    private int robotsDestruidos = 0;
    private int vidas = 3;

    void Start()
    {
        vidas = 3;
        ContadorVidas.text = vidas.ToString();

        robotsDestruidos = 0;
        contadorRobots.text = "0";

       // panelGameOver.SetActive(false); // oculta el panel al iniciar
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
    }

    // NUEVO: resta vida y verifica Game Over
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

    // NUEVO: activa panel de Game Over
    public void GameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    // NUEVO: método para botón "Reintentar"
    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // NUEVO: método para botón "Salir"
    public void SalirJuego()
    {
        Application.Quit();
    }
}
