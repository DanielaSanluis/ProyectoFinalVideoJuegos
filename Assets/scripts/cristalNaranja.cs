using UnityEngine;

public class cristalNaranja : MonoBehaviour
{
    public float tiempoVisible = 5f;
    public float duracionFlotacion = 5f;
    public float velocidadExtra = 6f;

    private bool activado = false;
    private bool fueTocado = false;

    void Start()
    {
        Invoke(nameof(Desaparecer), tiempoVisible);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            fueTocado = true;
            activado = true;
            ActivarFlotacion();
            gameObject.SetActive(false); // Desactiva el cristal tras tocarlo
        }
    }

    void Desaparecer()
    {
        if (!fueTocado)
        {
            activado = true;
            ActivarModoVelocidad();
            gameObject.SetActive(false); // Desactiva el cristal aunque no se haya tocado
        }
    }

    void ActivarFlotacion()
    {
        PerseguirJugador[] robots = Object.FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None);
        foreach (PerseguirJugador robot in robots)
        {
            robot.IniciarFlotacion(duracionFlotacion);
        }
    }

    void ActivarModoVelocidad()
    {
        PerseguirJugador[] robots = Object.FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None);
        foreach (PerseguirJugador robot in robots)
        {
            robot.AumentarVelocidad(velocidadExtra);
        }
    }
}
