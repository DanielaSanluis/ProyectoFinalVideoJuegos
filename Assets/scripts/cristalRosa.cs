using UnityEngine;

public class CristalRosa : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscar todos los robots en la escena
            PerseguirJugador[] todosLosRobots = GameObject.FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None);

            foreach (PerseguirJugador robot in todosLosRobots)
            {
                // Solo afectar a los robots normales (no los extras)
                if (!robot.esRobotExtra)
                {
                    Destroy(robot.gameObject);

                    // Sumar al contador de destruidos
                    prefs p = GameObject.Find("Canvas")?.GetComponent<prefs>();
                    if (p != null)
                    {
                        p.SumarRobotDestruido();
                    }
                }
            }

            // Desactivar el cristal después de activarse
            gameObject.SetActive(false);
        }
    }
}
