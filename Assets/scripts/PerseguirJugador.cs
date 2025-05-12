//using UnityEngine;
//using UnityEngine.AI;

//public class PerseguirJugador : MonoBehaviour
//{
//    private NavMeshAgent agente;
//    private Transform objetivo;

//    void Start()
//    {
//        agente = GetComponent<NavMeshAgent>();
//        StartCoroutine(EsperarPersonaje());
//    }

//    System.Collections.IEnumerator EsperarPersonaje()
//    {
//        while (DatosGlobales.personajeElegido == null)
//            yield return null;

//        objetivo = DatosGlobales.personajeElegido.transform;
//    }

//    void Update()
//    {
//        if (objetivo != null)
//        {
//            agente.SetDestination(objetivo.position);
//        }
//    }
//}


using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform objetivo;
    private Animator anim;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

            // Actualiza animación según la velocidad
            float velocidadActual = agente.velocity.magnitude;
            anim.SetFloat("Velocidad", velocidadActual);
        }
    }
}
