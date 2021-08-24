using System.Collections.Generic;
using UnityEngine;

public class PaintingWall : MonoBehaviour
{
    public List<Vector3> paintingSigns=new List<Vector3>(); //We created 1600 points to wall for checking percentage of painted wall
    public List<GameObject> testObjects =new List<GameObject>(); //To check if our system works
    public GameObject testObject; //Prefab object of signs
    public Bounds bounds; //We need bounds to create signs inside wall

    public int pointFrequency=40;

    void Awake()
    {
        bounds=GetComponent<Collider>().bounds;
        for(int i=0;i<pointFrequency;i++)
        {
            for(int j=0;j<pointFrequency;j++)
            {
                paintingSigns.Add(new Vector3((bounds.center.x-bounds.extents.x)+(j*bounds.extents.x*2)/pointFrequency,(bounds.center.y-bounds.extents.y)+(i*bounds.extents.y*2)/pointFrequency,bounds.center.z)); 
                //testObjects.Add(Instantiate(testObject,paintingSigns[paintingSigns.Count-1],Quaternion.identity));
            }
        }
    }
}