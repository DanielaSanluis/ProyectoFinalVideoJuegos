using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class prefs : MonoBehaviour
{
    public TMP_Text balas;
    /// <summary>
    /// /Start is called once before the first execution of Update after the MonoBehaviour is created
    /// </summary>

    public TMP_Text ContadorVidas;
    void Start()
    {
        //LE CAMBIE ESTABA ASI: int vidas = PlayerPrefs.GetInt("vidas", 3);
        PlayerPrefs.GetInt("vidas", 3);// 3 por defecto si no hay nada guardado
        int vidas = 3;
        ContadorVidas.text = vidas.ToString();
    }

    private void Awake()
    {
        balas.text = PlayerPrefs.GetInt("balas").ToString();
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
        PlayerPrefs.DeleteAll(); //borra todo
        PlayerPrefs.DeleteKey("balas");
        balas.text = "0";
    }
}

