using UnityEngine;

public class bala : MonoBehaviour
{
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
}
