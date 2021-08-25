using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text percentageOfPaintedArea,txt_1th,txt_2nd,txt_3rd;

    PaintingWall paintingWall;
    int divideValueOfSignFrequency; //To calculate % of painted area

    void Start() 
    {
        paintingWall=Manager.GetInstance().paintingWall.GetComponent<PaintingWall>();
        divideValueOfSignFrequency= (paintingWall.pointFrequency*paintingWall.pointFrequency)/100;
    }

    void LateUpdate() 
    {
        percentageOfPaintedArea.text=(GlobalAttributes.percentageOfPaintedArea/divideValueOfSignFrequency)+"%";
        txt_1th.text=GlobalAttributes.GetRacerByRank(0);
        txt_2nd.text=GlobalAttributes.GetRacerByRank(1);
        txt_3rd.text=GlobalAttributes.GetRacerByRank(2);
    }
    
    public void ChangeColorOfSpray(int sprayIndex)
    {
        GlobalAttributes.currentSprayColorIndex=sprayIndex;
        Manager.GetInstance().ChangeSprayColor();
    }
}