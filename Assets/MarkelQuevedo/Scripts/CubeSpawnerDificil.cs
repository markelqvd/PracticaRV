using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerDificl : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject bombCube;
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
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0;

        Vector3 spawnPos = spawnPoint.position + randomOffset;

        // Corrige aquí: guarda la instancia real
        GameObject selectedPrefab = Random.value < 0.2f ? bombCube : cubePrefab;
        GameObject cube = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        // Apuntar al torso
        Cube cubeScript = cube.GetComponent<Cube>();
        if (cubeScript != null && target != null)
        {
            float torsoOffset = 0.5f;
            Vector3 targetPos = new Vector3(target.position.x, target.position.y + torsoOffset, target.position.z);
            Vector3 directionToTarget = (targetPos - spawnPos).normalized;
            cubeScript.SetDirection(directionToTarget);
        }
    }

}