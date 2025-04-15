using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnDistance = 10f; // Distancia a la que aparecer�n los cubos
    public float spawnRate = 2f;      // Intervalo de aparici�n (en segundos)
    public float destinationOffsetRange = 2f; // Rango de offset para la direcci�n
    public float speed = 5f;          // Velocidad a la que se mueven los cubos

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        // Obtener la posici�n y direcci�n actual de la c�mara
        Transform cam = Camera.main.transform;

        // Calcular la posici�n de aparici�n
        Vector3 spawnPos = cam.position + cam.forward * spawnDistance;
        GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

        // Calcular la direcci�n de movimiento con un offset para mayor variedad
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 destination = new Vector3(cam.position.x + offset, cam.position.y, cam.position.z);
        Vector3 direction = (destination - spawnPos).normalized;

        // Asignar velocidad al cubo para que se mueva hacia el jugador
        cube.GetComponent<Rigidbody>().velocity = direction * speed;
    }
}

