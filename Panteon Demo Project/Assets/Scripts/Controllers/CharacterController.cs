using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    [SerializeField]
    float speed;

    protected bool rotating = false;
    bool run = true;

    Animator characterAnimator;

    // Vector3 startingPosition;

    // void Start()
    // {
    //     startingPosition = transform.position; //If we want to turn back to starting point like opponents when we hit any obstacle, we should write the code to here
    // }

    void Awake()
    {
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!run && GlobalAttributes.playerWon)
            return;
        if (transform.position.y < -1f)
            Restart();
        if (!rotating)
        {
            if (transform.position.x < -0.45f)
                transform.position = new Vector3(-0.45f, transform.position.y, transform.position.z);
            else if (transform.position.x > 0.45f)
                transform.position = new Vector3(0.45f, transform.position.y, transform.position.z); //Dont fall off
        }
        transform.Translate(new Vector3(0, 0, speed / 500)); //Moves character all the time
        if (rotating)
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Finish")
        {
            FinishLine();
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Obstacle")
        {
            Restart(); //Move character to starting position
        }
        if (c.gameObject.tag == "RotatingPlatform")
        {
            transform.SetParent(c.transform); //To move character with rotating platform
            rotating = true;
        }
        if (c.gameObject.tag == "Platform" && transform.parent != null)
        {
            transform.parent = null;
            if (rotating)
            {
                transform.parent = null;
                transform.rotation = Quaternion.Euler(Vector3.zero);
                rotating = false;
            }
        }
    }

    // void OnCollisionExit(Collision c) //Bug
    // {
    //     if (c.gameObject.tag == "RotatingPlatform")
    //     {
    //         transform.parent = null;
    //         transform.rotation = Quaternion.Euler(Vector3.zero);
    //         rotating = false;
    //         Debug.Log("out " + name);
    //     }
    // }

    public void MoveTo(float x)
    {
        if (!run)
            return;
        float speedX = Mathf.Clamp(x, -0.025f, 0.025f); //Slow down the character's horizontal speed if it is too fast
        transform.Translate(new Vector3(speedX, 0, 0));
    }

    public virtual void FinishLine()
    {
        run = false;
        characterAnimator.SetTrigger("Game Over");
    }

    public abstract void Restart();

}