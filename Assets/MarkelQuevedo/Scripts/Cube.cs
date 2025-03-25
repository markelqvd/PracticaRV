using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que colisiona tenga la tag "PlayerWeapon"
        if (other.CompareTag("PlayerWeapon"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.CubeDestroyed();
            }
            Destroy(gameObject);
        }
    }
}

