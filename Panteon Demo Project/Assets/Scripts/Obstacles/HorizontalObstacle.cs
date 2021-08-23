using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacle : MonoBehaviour
{
    [SerializeField]
    float speed, startingXPosition, finalXPosition; //Obstacle speed and positions to move between them

    [SerializeField]
    bool firstCycle; //Obstacle Starting Direction

    Vector3 startingPosition, finalPosition;

    void Start()
    {
        startingPosition = new Vector3(startingXPosition, transform.localPosition.y, transform.localPosition.z);
        finalPosition = new Vector3(finalXPosition, transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, (firstCycle ? finalPosition : startingPosition), speed * Time.deltaTime); //Moves between starting and final position all the time
        if (Vector3.Distance(transform.localPosition, startingPosition) < 0.001f)
        {
            firstCycle = true;
        }
        else if (Vector3.Distance(transform.localPosition, finalPosition) < 0.001f)
        {
            firstCycle = false;
        }
    }
}
