using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerDificil : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject bombCube;
    public float spawnDistance = 10f;         // Distancia fija desde la cámara para hacer spawn
    public float spawnRate = 2f;            // Intervalo de spawns
    public float destinationOffsetRange = 2f; // Rango de offset para variar el destino
    public float speed = 5f;                // Velocidad del cubo al moverse

    void Start()
    {
        InvokeRepeating("SpawnCube", 1f, spawnRate);
    }

    void SpawnCube()
    {
        // Obtener la cámara principal para conocer la posición y hacia dónde mira el jugador
        Transform cam = Camera.main.transform;

        // Calcular la posición de aparición: siempre a spawnDistance frente a la cámara
        Vector3 spawnPos = cam.position + cam.forward * spawnDistance;

        // Seleccionar el prefab a instanciar: bombCube con probabilidad 20%, sino cubePrefab
        GameObject selectedPrefab = (Random.value < 0.2f) ? bombCube : cubePrefab;
        GameObject cube = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        // Calcular el destino: se usa la posición actual de la cámara (jugador) con un pequeño offset
        float offset = Random.Range(-destinationOffsetRange, destinationOffsetRange);
        Vector3 targetPos = new Vector3(cam.position.x + offset, cam.position.y, cam.position.z);
        Vector3 direction = (targetPos - spawnPos).normalized;

        // Asignar la velocidad si el cubo tiene Rigidbody para que se dirija al jugador
        Rigidbody rb = cube.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }

        // Si el cubo posee un script adicional para manejar su comportamiento, se le pasa la dirección
        Cube cubeScript = cube.GetComponent<Cube>();
        if (cubeScript != null)
        {
            cubeScript.SetDirection(direction);
        }
    }
}
