using UnityEngine;

public class cristalNaranja : MonoBehaviour
{
    public float tiempoFlotar = 10f;
    public float velocidadRapida = 10f;
    public float tiempoRapido = 3f;
    public float tiempoDesaparicion = 5f; // Tiempo antes de que desaparezca automaticamente

    private bool activado = false;
    private float tiempoInicio;

    void Start()
    {
        tiempoInicio = Time.time;
    }

    void Update()
    {
        if (!activado && Time.time - tiempoInicio >= tiempoDesaparicion)
        {
            // desaparece aunque no sea tocado
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;

            PerseguirJugador[] robots = GameObject.FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None);

            foreach (PerseguirJugador robot in robots)
            {
                if (robot != null)
                {
                    if (JugadorTocoCristalAntesDe5Segundos())
                    {
                        robot.IniciarFlotacion(tiempoFlotar);
                    }
                    else
                    {
                        robot.AumentarVelocidadTemporal(velocidadRapida, tiempoRapido);
                    }
                }
            }

            gameObject.SetActive(false); // se desactiva al tocarlo
        }
    }

    private bool JugadorTocoCristalAntesDe5Segundos()
    {
        return Time.time - tiempoInicio <= tiempoDesaparicion;
    }
}
