using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform objetivo;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        StartCoroutine(EsperarPersonaje());
    }

    System.Collections.IEnumerator EsperarPersonaje()
    {
        while (DatosGlobales.personajeElegido == null)
            yield return null;

        objetivo = DatosGlobales.personajeElegido.transform;
    }

    void Update()
    {
        if (objetivo != null)
        {
            agente.SetDestination(objetivo.position);

            // Si tienes un Animator, actualiza velocidad
            Animator anim = GetComponent<Animator>();
            if (anim != null)
            {
                float vel = agente.velocity.magnitude;
                anim.SetFloat("Velocidad", vel);
            }
        }
    }
}
