using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class managerGuardado : MonoBehaviour
{
    public GameObject jugador;
    private string archivoGuardado;
    
    datosGuardado dg = new datosGuardado();

    private void Awake()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        archivoGuardado = Application.dataPath + "/datos.json";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            cargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            saveData();
        }
    }
        public void cargarDatos()
        {
        Debug.Log("CARGAR");
            if (File.Exists(archivoGuardado))
            {
                string contenido = File.ReadAllText(archivoGuardado);
                dg = JsonUtility.FromJson<datosGuardado>(contenido);
                Debug.Log(dg.position);
                jugador.transform.position = dg.position;
            }
           
        }

        public void saveData()
        {
        datosGuardado nuevosDatos = new datosGuardado()
        {
            position = jugador.transform.position
        };
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoGuardado, cadenaJSON);
        Debug.Log(cadenaJSON);
        }
}
