using UnityEngine;

public class cristalRosa : MonoBehaviour
{
    public GameObject cristalMorado; // Asignar desde el inspector (¡debe estar inactivo!)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Destruir los primeros 3 robots
            foreach (PerseguirJugador robot in FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None))
            {
                if (!robot.esRobotExtra)
                {
                    Destroy(robot.gameObject);
                }
            }

            // 2. Activar robots extra desde prefs
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.ActivarRobotsExtra(); // Este debe ser el método que ya tienes
                }
            }

            // 3. Activar el cristal morado
            if (cristalMorado != null)
            {
                cristalMorado.SetActive(true);
            }

            // 4. Destruir este cristal rosa
            Destroy(gameObject);
        }
    }
}
