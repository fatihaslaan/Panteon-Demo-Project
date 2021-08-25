using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : CharacterController
{
    Vector3 startingPosition;
    Manager manager;

    bool posChanged = false;

    void Start()
    {
        startingPosition = transform.position; //To start over
        manager = Manager.GetInstance();
        manager.characters.Add(this);
    }

    void LateUpdate()
    {
        if (GlobalAttributes.playerWon)
            return;
        foreach (GameObject obstacle in manager.obstacles)
        {
            if (Vector3.Distance(transform.position, obstacle.transform.position) < 0.75f) //We are close to an onstacle
            {
                if (transform.position.x > obstacle.transform.position.x && obstacle.transform.position.x + 0.2f < 0.45f) //Lets change our position
                    MoveTo(0.005f);
                else if (obstacle.transform.position.x - 0.2f > -0.45f)
                    MoveTo(-0.005f);
                posChanged = true; //We chaneg our position
            }
            else if (posChanged) //We are no longer close to an obstacle we can move to middle
            {
                if (transform.position.x > 0)
                    MoveTo(-0.0025f);
                else
                    MoveTo(0.0025f);
                if (Random.Range(0, 3) == 1) //Lets all move randomly
                    posChanged = false;
            }
        }
        if (rotating) //We are on top of rotating platform!
        {
            if (Random.Range(0, 9) < 7) //Someone should fall right?
            {
                if (transform.position.x > 0)
                    MoveTo(-0.1f);
                else if (transform.position.x < 0)
                    MoveTo(0.01f);
            }
        }
    }

    public override void Restart()
    {
        transform.position = startingPosition;
    }

    public override void FinishLine()
    {
        base.FinishLine();
        if (!GlobalAttributes.playerWon) //Player lost, he should try again
            SceneManager.LoadScene(0);
    }
}