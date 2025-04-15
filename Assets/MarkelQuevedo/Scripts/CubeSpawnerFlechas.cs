using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerFlechas : MonoBehaviour
{
    // Array con los 4 prefabs (bloques) que se pueden instanciar
    public GameObject[] blockPrefabs;

    public float spawnDistance = 10f;         // Distancia fija desde la c�mara para hacer spawn
    public float spawnRate = 2f;              // Intervalo de spawns
    public float destinationOffsetRange = 2f;   // Rango de offset para variar el destino
    public float speed = 5f;                  // Velocidad de movimiento del bloque

    void Start()
    {
        // Se invoca repetidamente el m�todo de spawn cada spawnRate segundos
        InvokeRepeating("SpawnCube", 1f, spawnRate);
    }

    void SpawnCube()
    {
        // Obtenemos la c�mara principal para determinar la posici�n y orientaci�n del jugador
        Transform cam = Camera.main.transform;

        // Calculamos la posici�n de aparici�n siempre a spawnDistance frente a la c�mara
        Vector3 spawnPos = cam.position + cam.forward * spawnDistance;

        // Seleccionamos aleatoriamente uno de los 4 prefabs
        int randomIndex = Random.Range(0, blockPrefabs.Length);
        GameObject block = Instantiate(blockPrefabs[randomIndex], spawnPos, Quaternion.identity);

        // Se a�ade un offset aleatorio a la posici�n del objetivo para darle variedad al movimiento
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 targetPos = new Vector3(cam.position.x + offset, cam.position.y, cam.position.z);
        Vector3 direction = (targetPos - spawnPos).normalized;

        // Asignamos la velocidad al bloque para que se desplace hacia el jugador
        Rigidbody rb = block.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }

        // Opcional: si el bloque cuenta con un script adicional para gestionar su direcci�n, se le indica la direcci�n calculada.
        Cube cubeScript = block.GetComponent<Cube>();
        if (cubeScript != null)
        {
            cubeScript.SetDirection(direction);
        }
    }
}
