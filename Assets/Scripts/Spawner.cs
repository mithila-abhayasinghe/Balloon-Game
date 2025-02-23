using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Balloon Settings")]
    public GameObject blueBalloonPF;
    public GameObject redBalloonPF;
    [Range(0, 1)] public float redBalloonChance = 0.3f;

    public float spawnRate;
    private float timer = 0;
    public float widthOffset = 10;

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
        
        GameObject chosenPrefab = Random.value < redBalloonChance ? redBalloonPF : blueBalloonPF;
        Instantiate(chosenPrefab, new Vector3(Random.Range(leftpoint, rightpoint), transform.position.y, 0), transform.rotation);

    }
}
