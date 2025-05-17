using UnityEngine;

public class camaraSeguir : MonoBehaviour
{
    private Transform objetivo;
    public Vector3 offset = new Vector3(0, 5, -10); // Ajusta la posición de la cámara respecto al personaje

    void Start()
    {
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
            transform.LookAt(objetivo);
        }
    }
}
