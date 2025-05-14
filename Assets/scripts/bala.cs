using UnityEngine;

public class bala : MonoBehaviour
{
    public GameObject dueño; // Quien disparó esta bala

    public float velocidad;
    public float tiempoVida = 2.0f;
    public Rigidbody rb;
    
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * velocidad;

        Destroy(this.gameObject, tiempoVida);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == dueño)
            return;

        if (gameObject.layer == LayerMask.NameToLayer("BalaJugador") && other.CompareTag("Robot"))
        {
            Debug.Log("Robot alcanzado por el jugador");

            // Sumar al contador
            GameObject canvas = GameObject.Find("Canvas"); // o el nombre real de tu Canvas
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.SumarRobotDestruido();
                }
            }

            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }


        if (gameObject.layer == LayerMask.NameToLayer("BalaRobot") && other.CompareTag("Jugador"))
        {
            int vidas = PlayerPrefs.GetInt("vidas", 3);
            vidas = Mathf.Max(vidas - 1, 0);
            PlayerPrefs.SetInt("vidas", vidas);
            PlayerPrefs.Save();

            Debug.Log("Jugador alcanzado por robot");
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }

}
