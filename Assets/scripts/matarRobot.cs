using UnityEngine;

public class matarRobot : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadDisparo = 15f;
    public float tiempoEntreDisparos = 2f;
    public float rangoDisparo = 100f;

    private float tiempoUltimoDisparo;
    private GameObject objetivo;

    void Update()
    {
        BuscarRobotCercano();

        if (objetivo == null) return;

        float distancia = Vector3.Distance(transform.position, objetivo.transform.position);

        if (distancia <= rangoDisparo && Time.time >= tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void BuscarRobotCercano()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
        float distanciaMin = Mathf.Infinity;
        GameObject masCercano = null;

        foreach (GameObject robot in robots)
        {
            float dist = Vector3.Distance(transform.position, robot.transform.position);
            if (dist < distanciaMin)
            {
                distanciaMin = dist;
                masCercano = robot;
            }
        }

        objetivo = masCercano;
    }

    void Disparar()
    {
        if (objetivo == null) return;

        Debug.Log("Compañero disparó a robot");

        transform.LookAt(new Vector3(objetivo.transform.position.x, transform.position.y, objetivo.transform.position.z));

        GameObject balaGO = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
        balaGO.layer = LayerMask.NameToLayer("BalaJugador"); // Usa la capa correcta si usas layers

        bala balaScript = balaGO.GetComponent<bala>();
        if (balaScript != null)
        {
            balaScript.dueño = gameObject;
        }

        Rigidbody rb = balaGO.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direccion = (objetivo.transform.position - puntoDisparo.position).normalized;
            rb.linearVelocity = direccion * velocidadDisparo;

            Collider colBala = balaGO.GetComponent<Collider>();
            Collider[] collsJugador = GetComponentsInChildren<Collider>();

            if (colBala != null)
            {
                foreach (Collider col in collsJugador)
                {
                    Physics.IgnoreCollision(colBala, col);
                }
            }
        }
    }

}
