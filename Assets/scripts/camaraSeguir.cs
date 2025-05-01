using UnityEngine;

public class camaraSeguir : MonoBehaviour
{
    private Transform objetivo; // El personaje a seguir
    public Vector3 offset = new Vector3(0, 5, -10); // Ajusta la posición de la cámara respecto al personaje

    void Start()
    {
        // Buscamos el personaje activo en la escena
        GameObject personajeActivo = GameObject.FindGameObjectWithTag("Player");
        if (personajeActivo != null)
        {
            objetivo = personajeActivo.transform;
        }
    }

    void LateUpdate()
    {
        if (objetivo != null)
        {
            transform.position = objetivo.position + offset;
            transform.LookAt(objetivo); // Opcional: que la cámara siempre mire al personaje
        }
    }
}
