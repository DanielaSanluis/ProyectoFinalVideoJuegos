using UnityEngine;

public class cristalMorado : MonoBehaviour
{
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
                    Debug.Log("Protección activada. Puedes recibir 3 golpes sin perder vidas.");
                }
            }

            Destroy(gameObject); // destruye el cristal morado 
        }
    }
}
