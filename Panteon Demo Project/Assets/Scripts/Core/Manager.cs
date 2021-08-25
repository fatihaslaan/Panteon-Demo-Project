using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour //To store some objects
{
    public GameObject spray, paintingWall, paintingUI, rankingUI;

    public List<Material> rotatingPlatformMaterials, sprayMaterials;

    public List<CharacterController> characters = new List<CharacterController>();

    public List<GameObject> obstacles;

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
            Load();
        }
    }

    void Load()
    {
        paintingWall = GameObject.FindGameObjectWithTag("Painting Wall");
        sprayRenderer = spray.GetComponent<Renderer>();
        ChangeSprayColor();
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle").ToList(); //AI will use it
    }

    public static Manager GetInstance()
    {
        return instance;
    }

    public void ChangeSprayColor()
    {
        sprayRenderer.material = sprayMaterials[GlobalAttributes.currentSprayColorIndex];
    }
}