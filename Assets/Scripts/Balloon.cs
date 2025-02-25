using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public Rigidbody2D balloon;
    public float speed = 5f;
    private bool wasClicked = false;

    // new
    private bool isRedBalloon;

    void Start()
    {
        isRedBalloon = gameObject.CompareTag("RedBalloon");
        //isObstacle = gameObject.CompareTag("Obstacle");
    }

    void Update()
    {
        // This is good but too fisyksy 
        //balloon.AddForceY(speed);

        // Stop updating when the object is destroyed
        if (gameObject != null)
        {
            Vector2 targetPositon = balloon.position + (Time.deltaTime * new Vector2 (0, speed));
            balloon.MovePosition(targetPositon);

        }
    }


    private void OnMouseDown()
    {

        wasClicked = true;
        // new
        if (GameManager.instance != null)
        {
            if (isRedBalloon)
            {
                GameManager.instance.HitRedBalloon();
            }
            else
            {
                GameManager.instance.PopBlueBalloon();
            }
        }
        Destroy(gameObject);

    }

    private void OnBecameInvisible()
    {
        if (!isRedBalloon && !wasClicked && GameManager.instance != null) {
            GameManager.instance.MissBlueBalloon();
            Destroy(gameObject);
        }
    }
}
