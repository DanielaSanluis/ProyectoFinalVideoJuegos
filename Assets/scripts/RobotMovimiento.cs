using UnityEngine;
using UnityEngine.AI;

public class RobotMovimiento : MonoBehaviour
{
    public Transform objetivo; // arrastra aquí al jugador o lo buscamos automáticamente
    private NavMeshAgent agente;
    private Animator animador;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();

        // Si no se asignó el objetivo manualmente, buscarlo por tag
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

        // Actualizar animación según velocidad
        float velocidadActual = agente.velocity.magnitude;
        animador.SetFloat("Velocidad", velocidadActual);
    }
}

