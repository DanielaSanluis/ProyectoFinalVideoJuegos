using UnityEngine;

public class cristalRosa : MonoBehaviour
{
    public GameObject cristalMorado; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // destruye los primeros 3 robots
            foreach (PerseguirJugador robot in FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None))
            {
                if (!robot.esRobotExtra)
                {
                    Destroy(robot.gameObject);
                }
            }

            // Activar robots extra desde prefs
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.ActivarRobotsExtra();
                }
            }

            // activa el cristal morado
            if (cristalMorado != null)
            {
                cristalMorado.SetActive(true);
            }

            // destrye este cristal rosa
            Destroy(gameObject);
        }
    }
}
