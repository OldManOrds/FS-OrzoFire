using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRateMin = 2f;
    public float spawnRateMax = 5f;
    public float moveSpeed = 3f;
    public float xRange = 5f;
    public float zRange = 5f;
    private Vector3 startPosition;
    private float nextSpawnTime = 0f;
    private bool moveRight = true;
    private bool moveForward = true;
    private float spawnRate;

    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        MoveSpawner();
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
    void MoveSpawner()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + xRange)
                moveRight = false;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - xRange)
                moveRight = true;
        }
        if (moveForward)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            if (transform.position.z >= startPosition.z + zRange)
                moveForward = false;
        }
        else
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
            if (transform.position.z <= startPosition.z - zRange)
                moveForward = true;
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
