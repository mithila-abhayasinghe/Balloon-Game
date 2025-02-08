using UnityEditor;
using UnityEngine;

public class Balllooon : MonoBehaviour
{
    public Rigidbody2D balloon;
    public float speed = 10f;

    void Start()
    {
        
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
        
    }


    private void OnMouseDown()
    {
        // Something about this function OnMouseDown 
        // you do not have to add this inside update always outside i think 

        // this only destroyed the rigidbody not the entire thing
        Destroy(balloon.gameObject);
        // we are setting this to be used inside update to stop accessing the 
        // object when it is destroyed
        ScoreManager.instance.IncreaseScore(1);
        balloon = null;

    }

}
