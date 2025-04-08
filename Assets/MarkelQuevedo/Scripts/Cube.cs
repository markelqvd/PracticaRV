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
        if (other.CompareTag("PlayerWeapon"))
        {
            if (CompareTag("Cube"))
            {
                GameManager.instance?.CubeDestroyed();
            }
            else if (CompareTag("Bomb"))
            {
                GameManager.instance?.BombDestroyed();
            }

            Destroy(gameObject);
        }
    }

}

