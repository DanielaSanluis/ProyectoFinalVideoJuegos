using UnityEngine;
using UnityEngine.AI;

public class PerseguirJugador : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform objetivo;
    private Rigidbody rb;

    public bool esRobotExtra = false;
    private Animator animator;

    private float velocidadOriginal;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (agente != null)
            velocidadOriginal = agente.speed;

        if (!esRobotExtra)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                    p.RegistrarRobot();
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
            Debug.Log("El robot tocó al jugador");

            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                    p.RestarVida();
            }
        }
    }

    // Flotar temporal
    public void IniciarFlotacion(float tiempo)
    {
        StartCoroutine(FlotarTemporalmente(tiempo));
    }

    private System.Collections.IEnumerator FlotarTemporalmente(float tiempo)
    {
        if (rb != null && agente != null)
        {
            agente.enabled = false;
            rb.isKinematic = false;
            rb.useGravity = false;
            rb.linearVelocity = new Vector3(0, 2f, 0); // flotar
        }

        yield return new WaitForSeconds(tiempo);

        if (rb != null && agente != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.useGravity = true;
            rb.isKinematic = true;
            agente.enabled = true;
        }
    }

    // Aumenta velocidad temporalmente
    public void AumentarVelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        StartCoroutine(VelocidadTemporal(nuevaVelocidad, duracion));
    }

    private System.Collections.IEnumerator VelocidadTemporal(float nuevaVelocidad, float duracion)
    {
        if (agente != null)
        {
            agente.speed = nuevaVelocidad;
            yield return new WaitForSeconds(duracion);
            agente.speed = velocidadOriginal;
        }
    }
}
