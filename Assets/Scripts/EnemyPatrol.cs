using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    public Animator animator;
    public int damageOnCollision = 20;

    Transform target;
    int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
        graphics.flipX = true;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // If enemy is on the target change the destpoint
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
