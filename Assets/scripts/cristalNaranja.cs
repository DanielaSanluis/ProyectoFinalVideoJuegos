using UnityEngine;

public class cristalNaranja : MonoBehaviour
{
    public float tiempoFlotar = 2f;
    public float velocidadRapida = 10f;
    public float tiempoRapido = 3f;

    private bool activado = false;

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

            gameObject.SetActive(false); // opcional, desaparece el cristal
        }
    }

    private bool JugadorTocoCristalAntesDe5Segundos()
    {
        // Reemplaza esto con tu lógica real
        return true; // o false según la condición real de tiempo
    }
}
