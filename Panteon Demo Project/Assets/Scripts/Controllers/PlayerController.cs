using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterController
{
    float horizontalMovement;

    float touchedPosition;

    bool paint = false;

    Manager manager;
    PaintingWall paintingWall;

    void Start()
    {
        manager = Manager.GetInstance();
        paintingWall = manager.paintingWall.GetComponent<PaintingWall>();
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchedPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            if (paint)
            {
                if (Input.mousePosition.y < (Screen.height / 2) && Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width) //Touch to customized area of screen to paint wall (We can adjust touching area easily, I choose half of the screen to paint wall)
                    PaintWall(Input.mousePosition); //Send screen coordinates
            }
            else
            {
                horizontalMovement = Input.mousePosition.x - touchedPosition;
            }
            touchedPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            horizontalMovement = 0f;
        }
        MoveTo(horizontalMovement / 500);
    }

    void PaintWall(Vector3 touchedPosition)
    {
        Vector3 paintingPos = GetPaintingPos(touchedPosition);
        for (int i = 0; i < paintingWall.paintingSigns.Count; i++) //Check all signs
        {
            if (Vector3.Distance(paintingWall.paintingSigns[i], paintingPos) < 0.03f) //We touched to a point that is close to sign
            {
                GlobalAttributes.percentageOfPaintedArea++; //We filled wall with a tiny spot!
                paintingWall.paintingSigns.RemoveAt(i); //Remove sign to not to paint it again
                //Destroy(wall.testObjects[i]); //See signs at real time and destroy them when painting
                //wall.testObjects.RemoveAt(i);
                break;
            }
        }
        Instantiate(manager.spray, paintingPos, Quaternion.Euler(-90, 0, 0));
    }

    Vector3 GetPaintingPos(Vector3 touchedPosition)
    {
        Vector3 tempVector = new Vector3((paintingWall.bounds.extents.x * 2) / Screen.width, (paintingWall.bounds.extents.y * 2) / (Screen.height / 2), paintingWall.bounds.center.z); //Temporary Vector for connection between screen and wall
        Vector3 paintingPos = new Vector3((paintingWall.bounds.center.x - paintingWall.bounds.extents.x) + (touchedPosition.x * tempVector.x), (paintingWall.bounds.center.y - paintingWall.bounds.extents.y) + (touchedPosition.y * tempVector.y), tempVector.z - paintingWall.bounds.extents.z * 1.2f);
        return paintingPos;
    }

    public override void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public override void FinishLine()
    {
        base.FinishLine();
        Camera.main.GetComponent<Animation>().Play();
        manager.paintingUI.SetActive(true);
        paint = true; //We are painting now!
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}