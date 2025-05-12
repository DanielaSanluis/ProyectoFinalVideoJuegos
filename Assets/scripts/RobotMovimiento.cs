using UnityEngine;
using UnityEngine.AI;

public class RobotMovimiento : MonoBehaviour
{
    public Transform objetivo; // arrastra aqu� al jugador o lo buscamos autom�ticamente
    private NavMeshAgent agente;
    private Animator animador;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();

        // Si no se asign� el objetivo manualmente, buscarlo por tag
        if (objetivo == null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
                objetivo = jugador.transform;
        }
    }

    void Update()
    {
        if (objetivo == null) return;

        // Moverse hacia el jugador
        agente.SetDestination(objetivo.position);

        // Actualizar animaci�n seg�n velocidad
        float velocidadActual = agente.velocity.magnitude;
        animador.SetFloat("Velocidad", velocidadActual);
    }
}

