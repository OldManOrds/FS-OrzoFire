using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        Instantiate(bullet, barrel.position, barrel.rotation);
    }
}