using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform objetivo;

    public bool esRobotExtra = false; 

    void Start()
    {
        if (!esRobotExtra)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.RegistrarRobot();
                }
            }
        }

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

            Animator anim = GetComponent<Animator>();
            if (anim != null)
            {
                float vel = agente.velocity.magnitude;
                anim.SetFloat("Velocidad", vel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El robot tocó al jugador");

            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.RestarVida();
                }
            }
        }
    }

}

