using UnityEngine;

public class FlotarCristal : MonoBehaviour
{
    public float velocidadFlotacion = 2f; // velocidad del movimiento vertical
    public float altura = 0.1f;           // cu�nto sube y baja
    public float velocidadRotacion = 70f; // grados por segundo

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlotacion) * altura;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);

        // Rotaci�n continua
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}

