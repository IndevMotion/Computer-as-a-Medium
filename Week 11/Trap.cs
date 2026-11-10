using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject hiddenObject;   // the thing that appears

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.health -= 10;
            hiddenObject.SetActive(true);   // makes it appear
        }
    }
}