using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour //To store some objects
{
    public GameObject spray,paintingWall,paintingUI;

    public List<Material> rotatingPlatformMaterials,sprayMaterials;

    public List<CharacterController> characters;

    Renderer sprayRenderer;

    static Manager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            paintingWall=GameObject.FindGameObjectWithTag("Painting Wall");
            sprayRenderer=spray.GetComponent<Renderer>();
            ChangeSprayColor();
        }
    }

    public static Manager GetInstance()
    {
        return instance;
    }

    public void ChangeSprayColor()
    {
        sprayRenderer.material=sprayMaterials[GlobalAttributes.currentSprayColorIndex];
    }
}