using UnityEngine;

public class bala : MonoBehaviour
{
    public GameObject dueño; // Quien disparó esta bala

    public float velocidad;
    public float tiempoVida = 2.0f;
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb.AddForce(transform.forward*velocidad*Time.deltaTime);

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
            Destroy(other.gameObject); // O reduce su vida
            Destroy(gameObject);
            Debug.Log("Robot moridoo alcanzado por el bala de jugador");
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
