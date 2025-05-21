using UnityEngine;

public class cristalRosa : MonoBehaviour
{
    public GameObject cristalMorado; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject canvas = GameObject.Find("Canvas");
            prefs p = canvas != null ? canvas.GetComponent<prefs>() : null;

            // destruye los primeros 3 robots
            foreach (PerseguirJugador robot in FindObjectsByType<PerseguirJugador>(FindObjectsSortMode.None))
            {
                if (!robot.esRobotExtra)
                {
                    Destroy(robot.gameObject);

                    // Llama a prefs para que cuente el robot destruido
                    if (p != null)
                    {
                        p.SumarRobotDestruido();
                    }
                }
            }

            // Activar robots extra desde prefs
            if (p != null)
            {
                p.ActivarRobotsExtra();
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
