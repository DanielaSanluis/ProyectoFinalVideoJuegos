using UnityEngine;

public class DisparoRobot : MonoBehaviour
{
    public GameObject proyectilPrefab; // Proyectil que va a disparar
    public Transform puntoDisparo;     // De dónde sale el disparo
    public float velocidadDisparo = 15f;
    public float tiempoEntreDisparos = 2f;
    public float rangoDisparo = 100f;

    private float tiempoUltimoDisparo;
    private Transform objetivo;

    void Start()
    {
        StartCoroutine(EsperarObjetivo());
    }

    System.Collections.IEnumerator EsperarObjetivo()
    {
        while (DatosGlobales.personajeElegido == null)
            yield return null;

        objetivo = DatosGlobales.personajeElegido.transform;
    }


    void Update()
    {
        
        if (objetivo == null) return;

        float distancia = Vector3.Distance(transform.position, objetivo.position);

        if (distancia <= rangoDisparo && Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        Debug.Log("¡Disparo robot!");

        transform.LookAt(new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z));

        GameObject balaGO = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        balaGO.layer = LayerMask.NameToLayer("BalaRobot");

        bala balaScript = balaGO.GetComponent<bala>();
        if (balaScript != null)
        {
            balaScript.dueño = gameObject;
        }

        Rigidbody rb = balaGO.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direccion = (objetivo.position - puntoDisparo.position).normalized;
            rb.linearVelocity = direccion * velocidadDisparo;

            Collider colBala = balaGO.GetComponent<Collider>();
            Collider[] collsRobot = GetComponentsInChildren<Collider>();

            if (colBala != null)
            {
                foreach (Collider colRobot in collsRobot)
                {
                    Physics.IgnoreCollision(colBala, colRobot);
                }
            }
        }
    }


}
