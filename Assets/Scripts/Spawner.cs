using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject balloonPF;
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

        Instantiate(balloonPF, new Vector3(Random.Range(leftpoint, rightpoint), transform.position.y, 0), transform.rotation);

    }
}
