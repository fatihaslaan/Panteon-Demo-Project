using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Vector3 startingPosition;

    // void Start()
    // {
    //     startingPosition = transform.position; //If we want to turn back to starting point like opponents when we hit any obstacle, we should write the code to here
    // }

    void Update()
    {
        if (transform.position.x < -0.45f)
            transform.position = new Vector3(-0.45f, transform.position.y, transform.position.z);
        else if (transform.position.x > 0.45f)
            transform.position = new Vector3(0.45f, transform.position.y, transform.position.z); //Dont fall off
        transform.Translate(new Vector3(0, 0, speed / 500)); //Moves character all the time
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Obstacle")
        {
            Restart(); //Move character to starting position
        }
    }

    public void MoveTo(float x)
    {
        float speedX = Mathf.Clamp(x, -0.05f, 0.05f); //Slow down the character if it is too fast
        transform.Translate(new Vector3(speedX, 0, 0));
    }

    public abstract void Restart();    

}
