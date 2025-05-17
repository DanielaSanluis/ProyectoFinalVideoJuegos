using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float velocidad, velocidadOriginal;
    public float gravedad;
    public float salto;
    public Vector3 direccion;
    public CharacterController cc;
    private Rigidbody rb;

    void Start()
    {
        this.cc = this.gameObject.GetComponent<CharacterController>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        direccion = Vector3.zero;
        direccion.y -= gravedad; //vertical
        direccion.x = Input.GetAxisRaw("Horizontal") * velocidad; //horizontal
        direccion.z = Input.GetAxisRaw("Vertical") * velocidad;
        //direccion = new Vector3(horizontal,gravedad,vertical);

        //this.transform.position += direccion*Time.deltaTime;
        cc.Move(direccion*Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space");
            direccion.y += salto;
            //rb.AddForce(direccion*salto, ForceMode.Impulse); //el rigidbody simula fisicas
        }
    }

    public void setVelocity(float velocidad) {
        this.velocidad = velocidad;
    }

    public void resetVelocity()
    {
        this.velocidad = velocidadOriginal;
    }
}
