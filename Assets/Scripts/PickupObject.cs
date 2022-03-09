using System.Collections;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public int cointValue = 1;
    public float pickupAnimationDuration = .4f;

    Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(pickupObject());
        }
    }

    private IEnumerator pickupObject ()
    {
        Inventory.instance.addCoins(cointValue);
        animator.SetBool("isPickup", true);
        yield return new WaitForSeconds(pickupAnimationDuration);
        Destroy(gameObject);
    }
}
