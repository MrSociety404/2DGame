using System.Collections;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public GameObject objectToAnim;
    public float deadAnimDuration = .24f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(destroyObject());
        }
    }

    private IEnumerator destroyObject ()
    {
        Animator animator = objectToAnim.GetComponent<Animator>();     
        animator.SetBool("isDead", true);
        objectToAnim.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(deadAnimDuration);
        Destroy(objectToDestroy);
    }
}
