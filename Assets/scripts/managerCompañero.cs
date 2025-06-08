using UnityEngine;

public class managerCompañero : MonoBehaviour
{
    public GameObject[] duplicadosCompañeros; // ← KaelDuplicado, NoahDuplicado, etc.
    public Transform puntoAparicionCompañero;
    private GameObject compañeroActivo;

    // Este método será llamado desde el cristal morado
    public void ActivarCompañeroAleatorio()
    {
        if (duplicadosCompañeros.Length == 0)
        {
            Debug.LogWarning("No hay duplicados de compañeros asignados.");
            return;
        }

        int indice = Random.Range(0, duplicadosCompañeros.Length);
        compañeroActivo = duplicadosCompañeros[indice];

        if (compañeroActivo.tag == "Player")
        {
            compañeroActivo.tag = "Untagged";
        }

        compañeroActivo.SetActive(true);

        if (puntoAparicionCompañero != null)
        {
            compañeroActivo.transform.position = puntoAparicionCompañero.position;
        }

        Debug.Log("Compañero activado: " + compañeroActivo.name);
    }
}
