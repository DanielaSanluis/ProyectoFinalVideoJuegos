using UnityEngine;
using System.Collections;

public class CristalMovimiento : MonoBehaviour
{
    public float tiempoEntreMovimientos = 3f;
    public float areaX = 10f;
    public float areaZ = 10f;

    private Vector3 posicionBase;

    void Start()
    {
        posicionBase = transform.position;
        StartCoroutine(MoverAleatoriamente());
    }

    IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreMovimientos);

            float offsetX = Random.Range(-areaX / 2, areaX / 2);
            float offsetZ = Random.Range(-areaZ / 2, areaZ / 2);

            Vector3 nuevaPosicion = new Vector3(
                posicionBase.x + offsetX,
                posicionBase.y,  // mantiene la altura original
                posicionBase.z + offsetZ
            );

            transform.position = nuevaPosicion;
        }
    }
}
