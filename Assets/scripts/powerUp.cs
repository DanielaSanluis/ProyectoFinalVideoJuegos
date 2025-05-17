using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class powerUp : MonoBehaviour
{
    public GameObject particleEffect; //para los hongos (azules)
    public float fuerzaEmpuje = 1000f; //fuerza de regreso para el jugador al tocar los hongos azules
    public TMP_Text ContadorVidas; // Aquí el texto que muestra las vidas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bala"))
        {
            Destroy(other.gameObject); // Destruye la bala
            Destroy(gameObject);       // Destruye este objeto (esfera, cubo, robot, hongo, cristal)
        }
        // Si el jugador toca el objeto
        else if (other.CompareTag("Player"))
        {
            if (particleEffect != null)
            {
                Destroy(Instantiate(particleEffect, transform.position, Quaternion.identity), 1.5f);
            }

            // Empuja al jugador
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                Vector3 direccion = (other.transform.position - transform.position).normalized;
                StartCoroutine(EmpujeJugador(other.transform, direccion));
            }

            // Si es hongo azul, le baja una vida y se destruye
            if (gameObject.CompareTag("BlueMush"))
            {
                GameObject canvas = GameObject.Find("Canvas"); 
                if (canvas != null)
                {
                    prefs p = canvas.GetComponent<prefs>();
                    if (p != null)
                    {
                        p.RestarVida(); 
                    }
                }


                Destroy(gameObject);
            }
            // Si es hongo morado, activa superpoder y se destruye
            else if (gameObject.CompareTag("PurpleMush"))
            {
                movimiento3d movimientoJugador = other.GetComponent<movimiento3d>();
                if (movimientoJugador != null)
                {
                    movimientoJugador.AumentarVelocidadYSalto();
                }

                Destroy(gameObject);
            }
            // Si es cristal y el jugador tiene menos de 3 vidas, se destruye
            else if (gameObject.CompareTag("Cristal"))
            {
                if (ContadorVidas != null)
                {
                    int vidas = int.Parse(ContadorVidas.text);
                    if (vidas < 3)
                    {
                        vidas += 1;
                        ContadorVidas.text = vidas.ToString();
                        PlayerPrefs.SetInt("vidas", vidas);
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

        //corrutina
        IEnumerator EmpujeJugador(Transform jugador, Vector3 direccion)
        {
            float duracion = 0.2f;
            float fuerza = 6f;

            float tiempo = 0f;
            while (tiempo < duracion)
            {
                jugador.GetComponent<CharacterController>().Move(direccion * fuerza * Time.deltaTime);
                tiempo += Time.deltaTime;
                yield return null;
            }
        }
    }
