
using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject hiddenObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.health -= 10;

            StartCoroutine(ShowTrapEffect());
        }
    }

    private IEnumerator ShowTrapEffect()
    {
        hiddenObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        hiddenObject.SetActive(false);
    }
}
