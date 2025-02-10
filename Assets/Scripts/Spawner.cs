using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Balloon Settings")]
    public GameObject balloonPF;
    [Range(0, 1)] public float obstacleChange = 0.3f;
    public GameObject obstaclePF;

    public float spawnRate;
    private float timer = 0;
    public float widthOffset = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }else
        {
            SpawnBalloon();
            timer = 0;
        }


    }

    void SpawnBalloon()
    {
        float leftpoint = transform.position.x - widthOffset;
        float rightpoint = transform.position.x + widthOffset;
        
        GameObject chosenPrefab = Random.value < obstacleChange ? obstaclePF : balloonPF;
        Instantiate(chosenPrefab, new Vector3(Random.Range(leftpoint, rightpoint), transform.position.y, 0), transform.rotation);

    }
}
