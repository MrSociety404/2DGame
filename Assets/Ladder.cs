using UnityEngine;

public class Ladder : MonoBehaviour
{

    public bool isInRange;
    PlayerMovement playerMovement;
    BoxCollider2D platformCollider;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        platformCollider = gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Z))
        {
            playerMovement.isClimbing = true;
            platformCollider.isTrigger = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            platformCollider.isTrigger = false;
        }
    }
}
