using Unity.VisualScripting;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Camera mainCamera;
    public Transform gun;
    public float rotationSpeed = 1000f;
    public float speed = 100f;
    public float maxX = 75f;
    public float minX = -75f;

    void Update()
    {
        AimAtMouse();
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            GameManager.Instance.AddDeath(1);
        }
    }

    void MovePlayer()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        float newXPosition = transform.position.x + moveDirection * speed * Time.deltaTime;
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }

    void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Vector3 direction = pointToLook - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (gun != null)
            {
                gun.rotation = transform.rotation;
            }
        }
    }
}