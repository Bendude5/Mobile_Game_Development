using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int savedScore;

    public PlayerData (Score scoreObject)
    {
        savedScore = scoreObject.scoreValue;
    }
}
