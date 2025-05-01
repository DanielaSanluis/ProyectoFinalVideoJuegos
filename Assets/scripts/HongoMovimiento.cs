using UnityEngine;
using System.Collections;

public class HongoMovimiento : MonoBehaviour
{
    public float tiempoEntreMovimientos = 2f; // cada cuántos segundos se mueve
    public float areaX = 40f; // tamaño del plano en el eje X (ajústalo)
    public float areaZ = 40f; // tamaño del plano en el eje Z (ajústalo)
    //public float altura = 1f; // altura fija a la que quieres que flote el hongo

    private void Start()
    {
        StartCoroutine(MoverAleatoriamente());
    }

    IEnumerator MoverAleatoriamente()
    {
        while (true)
        {
            // Espera un tiempo antes de moverse
            yield return new WaitForSeconds(tiempoEntreMovimientos);

            // Calcula una nueva posición aleatoria
            float nuevaX = Random.Range(-areaX / 2, areaX / 2);
            float nuevaZ = Random.Range(-areaZ / 2, areaZ / 2);
            Vector3 nuevaPosicion = new Vector3(nuevaX, 0.66f, nuevaZ);

            // Mueve el hongo
            transform.position = nuevaPosicion;
        }
    }
}
