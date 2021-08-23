using UnityEngine;

public class RotatingObstacleBehaviour : MonoBehaviour
{
    [SerializeField] 
    Vector3 rotateSpeed;

    Vector3 rotation;

    void Update()
    {
        transform.localRotation=Quaternion.Euler(rotation.x,rotation.y,rotation.z);
        rotation+=rotateSpeed;
    }
}