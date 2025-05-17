using UnityEngine;

public class FlotarCristal : MonoBehaviour
{
    public float velocidadFlotacion = 2f;
    public float altura = 0.1f;
    public float velocidadRotacion = 70f;

    private float alturaBase;

    void Start()
    {
        alturaBase = transform.position.y; 
    }

    void Update()
    {
        float nuevaY = alturaBase + Mathf.Sin(Time.time * velocidadFlotacion) * altura;

        Vector3 posicionActual = transform.position;
        transform.position = new Vector3(posicionActual.x, nuevaY, posicionActual.z);

        // Rotacion
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}

