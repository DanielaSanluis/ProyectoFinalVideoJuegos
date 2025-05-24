using UnityEngine;

public class cristalMorado : MonoBehaviour
{
    public SpawnerCompanero spawner; //para que aparezca un compe�aero

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //para que aparezca un compa�ero
            Debug.Log("Jugador toc� el cristal morado.");

            if (spawner == null)
            {
                Debug.LogWarning("�SpawnerCompanero no est� asignado!");
                return;
            }

            int index = spawner.companeroIndexSeleccionado;
            Debug.Log("�ndice del compa�ero: " + index);

            if (index >= 0)
            {
                GameObject companero = spawner.personajesEnEscena[index];
                if (companero != null)
                {
                    companero.SetActive(true);
                    Debug.Log("Compa�ero activado desde cristal: " + companero.name);
                }
                else
                {
                    Debug.LogWarning("El objeto compa�ero es null.");
                }
            }
            else
            {
                Debug.LogWarning("�ndice de compa�ero inv�lido.");
            }

            //se activan las protecciones (vidas extra)
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

                    if (p.ContadorVidasExtra  != null)
                    {
                        p.ContadorVidasExtra.text = p.proteccionesRestantes.ToString();
                        p.ContadorVidasExtra.gameObject.SetActive(true); //tambien se active el contador de vidas extra 
                    }
                }
            }
            //para que aparezca un compa�ero
            /*
            int index = spawner.companeroIndexSeleccionado;
            if (index >= 0)
            {
                spawner.personajesEnEscena[index].SetActive(true);
                Debug.Log("Compa�ero activado desde cristal.");
            }
            */

            Destroy(gameObject); // destruye el cristal morado 
        }
    }
}
