using UnityEngine;

public class cristalMorado : MonoBehaviour
{
    public SpawnerCompanero spawner; //para que aparezca un compeñaero

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //para que aparezca un compañero
            Debug.Log("Jugador tocó el cristal morado.");

            if (spawner == null)
            {
                Debug.LogWarning("¡SpawnerCompanero no está asignado!");
                return;
            }

            int index = spawner.companeroIndexSeleccionado;
            Debug.Log("Índice del compañero: " + index);

            if (index >= 0)
            {
                GameObject companero = spawner.personajesEnEscena[index];
                if (companero != null)
                {
                    companero.SetActive(true);
                    Debug.Log("Compañero activado desde cristal: " + companero.name);
                }
                else
                {
                    Debug.LogWarning("El objeto compañero es null.");
                }
            }
            else
            {
                Debug.LogWarning("Índice de compañero inválido.");
            }

            //se activan las protecciones (vidas extra)
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                prefs p = canvas.GetComponent<prefs>();
                if (p != null)
                {
                    p.proteccionesRestantes = 3;
                    Debug.Log("Protección activada. Puedes recibir 3 golpes sin perder vidas.");

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
            //para que aparezca un compañero
            /*
            int index = spawner.companeroIndexSeleccionado;
            if (index >= 0)
            {
                spawner.personajesEnEscena[index].SetActive(true);
                Debug.Log("Compañero activado desde cristal.");
            }
            */

            Destroy(gameObject); // destruye el cristal morado 
        }
    }
}
