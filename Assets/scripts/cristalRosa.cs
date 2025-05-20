using UnityEngine;

public class cristalRosa : MonoBehaviour
{
    public GameObject efectoMuerte; // opcional: partículas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Busca todos los objetos con el script PerseguirJugador
            PerseguirJugador[] robots = Object.FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None);

            foreach (PerseguirJugador robot in robots)
            {
                if (!robot.esRobotExtra) // Solo mata a los primeros 3
                {
                    if (efectoMuerte != null)
                    {
                        Instantiate(efectoMuerte, robot.transform.position, Quaternion.identity);
                    }

                    Destroy(robot.gameObject);
                }
            }

            Destroy(gameObject); // Destruye el cristal rosa
        }
    }
}
