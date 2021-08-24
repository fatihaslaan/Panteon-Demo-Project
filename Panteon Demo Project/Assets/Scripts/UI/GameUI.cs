using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text percentageOfPaintedArea;

    PaintingWall paintingWall;
    int divideValueOfSignFrequency; //To calculate % of painted area

    void Start() 
    {
        paintingWall=Manager.GetInstance().paintingWall.GetComponent<PaintingWall>();
        divideValueOfSignFrequency= (paintingWall.pointFrequency*paintingWall.pointFrequency)/100;
    }

    void Update() 
    {
        percentageOfPaintedArea.text=(GlobalAttributes.percentageOfPaintedArea/divideValueOfSignFrequency)+"%";
    }
    
    public void ChangeColorOfSpray(int sprayIndex)
    {
        GlobalAttributes.currentSprayColorIndex=sprayIndex;
        Manager.GetInstance().ChangeSprayColor();
    }
}