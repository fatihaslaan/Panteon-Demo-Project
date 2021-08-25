using System.Linq;

public static class GlobalAttributes
{
    public static int currentSprayColorIndex=1;
    public static float percentageOfPaintedArea=0;

    public static bool playerWon=false;

    public static string GetRacerByRank(int index)
    {
        return Manager.GetInstance().characters.OrderByDescending(character => character.transform.position.z).ToList()[index].name;
    }
}