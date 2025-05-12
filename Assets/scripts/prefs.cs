using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class prefs : MonoBehaviour
{
    public TMP_Text balas;
     public TMP_Text ContadorVidas;
    public TMP_Text contadorRobots;
    private int robotsDestruidos = 0;

    void Start()
    {
        //LE CAMBIE ESTABA ASI: int vidas = PlayerPrefs.GetInt("vidas", 3);
        PlayerPrefs.GetInt("vidas", 3);// 3 por defecto si no hay nada guardado
        int vidas = 3;
        ContadorVidas.text = vidas.ToString();

        // Reiniciar contador de robots
        robotsDestruidos = 0;
        contadorRobots.text = "0";
    }

    private void Awake()
    {
       // balas.text = PlayerPrefs.GetInt("balas").ToString();
       loadData();
    }
    public void saveData()
    {
        //solo almacenan int, float y string, solo se debería de usar para almacenar configuraciones
        PlayerPrefs.SetInt("balas", int.Parse(balas.text)); //si la llave no existe, entonces la crea
    }

    public int loadData()
    {
        int puntos = PlayerPrefs.GetInt("balas");
        balas.text = puntos.ToString();
        return puntos;
    }

    public void erraseData()
    {
        //PlayerPrefs.DeleteAll(); //borra todo
        PlayerPrefs.DeleteKey("balas");
        balas.text = "0";
    }

    public void SumarRobotDestruido()
    {
        robotsDestruidos++;
        contadorRobots.text = robotsDestruidos.ToString();
    }

}
