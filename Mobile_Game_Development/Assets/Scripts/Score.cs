using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text _score;
    public int scoreValue;

    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Pause>().isPaused == false)
        {
            scoreValue += 1;
            _score.text = "Score: " + scoreValue;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            this.SaveScore();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            this.LoadScore();
        }
    }

    public void SaveScore()
    {
        Debug.Log("Save Score");
        SaveSystem.saveScore(this);
    }

    public void LoadScore()
    {
        Debug.Log("Load Score");
        PlayerData data = SaveSystem.LoadScore();

        scoreValue = data.savedScore;
    }
}
