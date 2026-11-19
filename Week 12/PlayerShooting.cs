
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Align the bullet with the direction
            // the player is facing.
            Quaternion bulletRotation =
                firePoint.rotation *
                Quaternion.Euler(0f, 0f, -90f);

            Instantiate(
                bulletPrefab,
                firePoint.position,
                bulletRotation
            );
        }
    }
}
