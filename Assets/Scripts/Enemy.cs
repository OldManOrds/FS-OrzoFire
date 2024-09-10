using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float stopDistance = 4f;
    private Animator animator;
    private bool isDead = false;
    private float fixedY;
    public Transform enemy;

    void Start()
    {
        fixedY = transform.position.y;
        animator = GetComponent<Animator>();
        
        if (player != null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }
    }

    void Update()
    {
        TrackPlayer();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Destroy(gameObject, 0.5f);
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        GameManager.Instance.AddKill(1);
        Destroy(gameObject,0.5f);
    }

    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!isDead)
            {
                Die();
            }
        }if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
        

    }

    void TrackPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > stopDistance)
            {
                Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;
                newPosition.y = fixedY;
                transform.position = newPosition;
                Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
                Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
            }

            else
            {
                Attack();
            }
        }
    }
}
