using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private Transform jugador;
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        // Buscar al jugador con tag "Player"
        GameObject objJugador = GameObject.FindGameObjectWithTag("Player");
        if (objJugador != null)
        {
            jugador = objJugador.transform;
        }
    }

    void Update()
    {
        if (jugador != null && agente.enabled)
        {
            agente.SetDestination(jugador.position); // Esta línea debe estar en Update
        }
    }


}
