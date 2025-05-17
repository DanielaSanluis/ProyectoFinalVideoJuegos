using UnityEngine;
using TMPro;
using System.Collections;

public class movimiento3d : MonoBehaviour
{
    CharacterController controlador;
    Animator anim;

    // Variables de movimiento
    public Vector3 direccion;
    public float gravedad = 9.81f; 
    public float rotacion;
    public float velRotacion = 5f;
    public float salto = 7f; 
    public float velocidad = 5f;
    public float ver;

    // Variables para armas
    public Transform holder;
    public GameObject zooka;
    public GameObject bala;

    //contador de balas
    public int numBalas;
    public TMP_Text balas;

    public AudioSource audioSource;
    public AudioClip disparoClip;

    // <summary>
    // Inicializa las referencias a los componentes.
    // </summary>

    private void Awake()
    {
        if (PlayerPrefs.HasKey("balas"))
        {
            numBalas = PlayerPrefs.GetInt("balas");
        } else {
            numBalas = 0;
        }
    }

    void Start()
    {
        controlador = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        //audioSource.PlayOneShot(disparoClip);
        audioSource = GetComponent<AudioSource>();
        // Verificar si el AudioSource existe antes de usarlo
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en el personaje.");
        }
    }

    // <summary>
    // Se ejecuta en cada frame y gestiona el movimiento, la rotacion, el salto y las animaciones.
    // </summary>

    void Update()
    {
        //verifica si el personaje esta en el suelo
        if (controlador.isGrounded)
        {
            //configuracion de animaciones cuando esta en el suelo
            anim.SetBool("suelo", true);
            anim.ResetTrigger("jump");
            anim.SetBool("jumpLand", false);

            //captura entrada de movimiento vertical
            ver = Input.GetAxisRaw("Vertical");
            direccion = transform.TransformDirection(new Vector3(0, 0, ver) * velocidad);
            rotacion = Input.GetAxis("Horizontal") * velRotacion;

            //configura animaciones de movimiento
            anim.SetFloat("move", ver);
            anim.SetBool("idle", ver == 0);

            //salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direccion.y = salto; // Aplica solo la fuerza de salto
                anim.SetTrigger("jump");
                anim.SetBool("suelo", false);
            }
        }
        else
        {
            anim.SetBool("suelo", false);

            // Si está cayendo, aceleramos la caída para evitar que flote (aplica gravedad extra al caer)
            if (direccion.y < 0)
            {
                direccion.y -= gravedad * 1.5f * Time.deltaTime; // Caída más rápida pero con la misma gravedad
                anim.SetBool("jumpLand", true);
            }
        }

        // Aplicamos la gravedad normal
        direccion.y -= gravedad * Time.deltaTime;

        //aplicar rotacion y movimiento
        controlador.transform.Rotate(new Vector3(0, rotacion, 0));
        controlador.Move(direccion * Time.deltaTime);

        //disparar si se presiona "C" y el lanzacohetes esta activo
        if (Input.GetKeyDown(KeyCode.C)&& zooka.activeSelf) //zooka.activeself, para que no dispare cuando no esta prendida la bazuca
        {
            //Instantiate(bala, holder.position, holder.rotation); //quaternoo.identity
            
            //intanciar una nueva bala en la posicion del holder
            GameObject nuevaBala = Instantiate(bala, holder.position, holder.rotation);
            Rigidbody rb = nuevaBala.GetComponent<Rigidbody>();

            //aumenta contador de balas
            //numBalas++;
            //balas.text = numBalas.ToString();

            //aplicar fuerza a la bala si tiene un rigidbody
            if (rb != null)
            {
                rb.linearVelocity = holder.forward * 2f; // Ajusta la velocidad de la bala
            }

            // Reproducir el sonido al disparar
            if (audioSource != null && disparoClip != null)
            {
                audioSource.PlayOneShot(disparoClip);
            }
            else
            {
                Debug.LogWarning("AudioSource o DisparoClip no están asignados.");
            }
        }
    }

    // <summary>
    // Detecta colisiones con objetos tipo "gun" para recoger el lanzacohetes.
    // </summary>
    // <param name="other">Collider del objeto con el que colisiona.</param>

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gun")
        {
            //other.gameObject.transform.position = holder.position;
            //other.gameObject.transform.parent = this.gameObject.transform;
            other.gameObject.SetActive(false); //desactiva el objeto recogido
            zooka.SetActive(true); //activa el lanzacohetes en el personaje
        }
    }

    public void AumentarVelocidadYSalto()
    {
        velocidad += 20f; 
        salto += 5f; 

        StartCoroutine(RestaurarVelocidadYSalto());
    }

    private IEnumerator RestaurarVelocidadYSalto()
    {
        yield return new WaitForSeconds(7f); // El poder dura 5 segundos

        velocidad -= 20f;
        salto -= 5f;
    }

}
