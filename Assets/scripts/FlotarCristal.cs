//using UnityEngine;

//public class FlotarCristal : MonoBehaviour
//{
//    public float velocidadFlotacion = 2f; // velocidad del movimiento vertical
//    public float altura = 0.1f;           // cuánto sube y baja
//    public float velocidadRotacion = 70f; // grados por segundo

//    private Vector3 posicionInicial;

//    void Start()
//    {
//        posicionInicial = transform.position;
//    }

//    void Update()
//    {
//        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlotacion) * altura;
//        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);

//        // Rotación continua
//        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
//    }
//}

//Lo de arriba lo dejo en caso de que no se quiera que los cristales se muevan eleatoriamente por el terreno y solo floten.
//En dado caso borro lo de abajo y me quedo con lo comentado y borro el scrip de movimiento de los cristales.
using UnityEngine;

public class FlotarCristal : MonoBehaviour
{
    public float velocidadFlotacion = 2f;
    public float altura = 0.1f;
    public float velocidadRotacion = 70f;

    private float alturaBase;

    void Start()
    {
        alturaBase = transform.position.y; // Solo guarda la Y inicial
    }

    void Update()
    {
        // Calcula nueva altura flotando, manteniendo X y Z actuales
        float nuevaY = alturaBase + Mathf.Sin(Time.time * velocidadFlotacion) * altura;

        Vector3 posicionActual = transform.position;
        transform.position = new Vector3(posicionActual.x, nuevaY, posicionActual.z);

        // Rotar continuamente sobre el eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}

