using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform objetivo;
    private Rigidbody rb; //rigitbody para gravedad AGREGADO NUEVO PRUEVA

    public bool esRobotExtra = false; 
    private Animator animator; //para nivel5

    void Start()
    {
        agente = GetComponent<NavMeshAgent>(); //para nivel5
        rb = GetComponent<Rigidbody>(); //para nivel5
        animator = GetComponent<Animator>(); //para nivel 5

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
        if (objetivo != null && agente.enabled)
        {
            agente.SetDestination(objetivo.position);

            if (animator != null)
            {
                float vel = agente.velocity.magnitude;
                animator.SetFloat("Velocidad", vel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El robot toc� al jugador");

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

    // para que el robot flote
    public void IniciarFlotacion(float tiempo)
    {
        StartCoroutine(FlotarTemporalmente(tiempo));
    }

    private System.Collections.IEnumerator FlotarTemporalmente(float tiempo)
    {
        if (rb != null)
        {
            agente.enabled = false;
            rb.isKinematic = false;
            rb.useGravity = false;
            rb.linearVelocity = new Vector3(0, 2f, 0); // flotar hacia arriba
        }

        yield return new WaitForSeconds(tiempo);

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.useGravity = true;
            rb.isKinematic = true;
            agente.enabled = true;
        }
    }

    // para aumentar velocidad de persecuci�n
    public void AumentarVelocidad(float nuevaVelocidad)
    {
        if (agente != null)
            agente.speed = nuevaVelocidad;
    }

}

