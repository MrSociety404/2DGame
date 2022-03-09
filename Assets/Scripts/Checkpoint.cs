using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    Transform playerSpawn;
    GameObject torch;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        torch = gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            torch.GetComponent<Animator>().SetBool("isChecked", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
