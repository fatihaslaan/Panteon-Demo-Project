using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : CharacterController
{
    float horizontalMovement;

    float touchedPosition;

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchedPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            horizontalMovement = Input.mousePosition.x - touchedPosition;
            touchedPosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            horizontalMovement = 0f;
        }
        //horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime;
        MoveTo(horizontalMovement/500);
    }

    public override void Restart()
    {
        SceneManager.LoadScene(0);
    }
}