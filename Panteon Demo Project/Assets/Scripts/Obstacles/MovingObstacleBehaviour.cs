using UnityEngine;

public class MovingObstacleBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed; //Obstacle speed and 

    [SerializeField]
    Vector3 startingPosition, finalPosition; //Obstacle positions to move between them

    [SerializeField]
    bool firstCycle; //Obstacle Starting Direction

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