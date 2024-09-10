using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float duration = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, duration);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}