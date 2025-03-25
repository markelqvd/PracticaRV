using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;     // Prefab del cubo
    public Transform spawnPoint;      // Centro de la zona de spawn
    public float spawnRadius = 5f;      // Radio de generación aleatoria
    public float spawnRate = 1.5f;      // Tiempo entre spawns

    // Referencia al target (jugador o su torso)
    public Transform target;

    void Start()
    {
        InvokeRepeating("SpawnCube", 1f, spawnRate);
    }

    void SpawnCube()
    {
        // Genera un offset aleatorio dentro de una esfera de radio spawnRadius
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        // Si deseas que la altura sea fija, puedes forzar el componente Y:
        randomOffset.y = 0;

        Vector3 spawnPos = spawnPoint.position + randomOffset;
        GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

        // Configura la dirección para que el cubo se mueva hacia el jugador (torso)
        Cube cubeScript = cube.GetComponent<Cube>();
        if (cubeScript != null && target != null)
        {
            // Suponiendo que target representa la posición de los pies y quieres apuntar al torso,
            // añade un offset en Y (ajústalo según tu modelo, por ejemplo 0.5f)
            float torsoOffset = 0.5f;
            Vector3 targetPos = new Vector3(target.position.x, target.position.y + torsoOffset, target.position.z);

            // Calcula la dirección desde la posición del spawn hasta el torso del jugador
            Vector3 directionToTarget = (targetPos - spawnPos).normalized;
            cubeScript.SetDirection(directionToTarget);
        }
    }
}
