using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHitZone : MonoBehaviour
{
    // Referencia al cubo padre; se puede asignar desde el Inspector o buscarlo en Awake.
    public Cube parentCube;

    void Awake()
    {
        if (parentCube == null)
        {
            parentCube = GetComponentInParent<Cube>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se asume que el arma del jugador tiene la etiqueta "PlayerWeapon"
        if (other.CompareTag("PlayerWeapon"))
        {
            // Llamamos al método del padre que ejecuta la lógica de destrucción y puntuación.
            parentCube.OnCorrectHit();
        }
    }
}
