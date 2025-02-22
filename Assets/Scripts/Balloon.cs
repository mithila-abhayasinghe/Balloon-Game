using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Rigidbody2D balloon;
    public float speed = 5f;
    private bool isObstacle;
    public float deadzone = 15f;
    void Start()
    {
        isObstacle = gameObject.CompareTag("Obstacle");
    }

    void Update()
    {
        // This is good but too fisyksy 
        //balloon.AddForceY(speed);

        // Stop updating when the object is destroyed
        if (balloon != null)
        {
            Vector2 targetPositon = balloon.position + (Time.deltaTime * new Vector2 (0, speed));
            balloon.MovePosition(targetPositon);

        }
        if (balloon.position.y > deadzone)
        {
            Destroy(balloon);
        }
    }


    private void OnMouseDown()
    {

        if (!isObstacle)
        {
            GameManager.instance.PopBalloon();
            Destroy(gameObject);
        }
        else
        {
            GameManager.instance.HitObstacle();
            Destroy(gameObject);
        }


    }

    private void OnBecameInvisible()
    {
        if (!isObstacle && balloon != null) {
            GameManager.instance.MissBalloon();
            Destroy(balloon.gameObject);
        }
    }
}
