using UnityEngine;

public class cristalMorado : MonoBehaviour
{
    public managerCompa�ero manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.proteccionesRestantes = 3;
                    Debug.Log("Protecci�n activada. Puedes recibir 3 golpes sin perder vidas.");

                    // Mostrar contador de protecciones (de vidas extra)
                    if (p.vidasExtra != null)
                        p.vidasExtra.SetActive(true);

                    if (p.ContadorVidasExtra != null)
                    {
                        p.ContadorVidasExtra.text = p.proteccionesRestantes.ToString();

                        p.ContadorVidasExtra.gameObject.SetActive(true); //tambien se active el contador de vidas extra 
                    }
                }
            }

            // se activa al compa�ero aleatorio
            if (manager != null)
            {
                manager.ActivarCompa�eroAleatorio();
            }

            Destroy(gameObject); // destruye el cristal morado 
        }
    }
}