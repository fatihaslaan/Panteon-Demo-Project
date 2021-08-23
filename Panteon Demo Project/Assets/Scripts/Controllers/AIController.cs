using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : CharacterController
{
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position; //To start over
    }

    public override void Restart()
    {
        transform.position = startingPosition;
    }
}
