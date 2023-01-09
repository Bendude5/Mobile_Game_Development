using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int savedScore;
    public string savedTime;

    public PlayerData (Score scoreObject)
    {
        //Saves these components of the score
        savedScore = scoreObject.highScore;
        savedTime = scoreObject.highScoreTime;
    }
}
