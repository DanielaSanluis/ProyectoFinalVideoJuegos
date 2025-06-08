using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class perseguirRobot : MonoBehaviour
{
    private NavMeshAgent agente;
    private GameObject objetivoActual;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        BuscarRobotCercano();

        if (objetivoActual != null)
        {
            agente.SetDestination(objetivoActual.transform.position);

            Animator anim = GetComponent<Animator>();
            if (anim != null)
            {
                float vel = agente.velocity.magnitude;
                anim.SetFloat("Velocidad", vel);
            }
        }
        if (agente == null || !agente.enabled) return;
    }

    void BuscarRobotCercano()
    {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot"); // con esto ahora persigue al robot
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

        objetivoActual = masCercano; //persigue al robot mas cercano
    }
}
