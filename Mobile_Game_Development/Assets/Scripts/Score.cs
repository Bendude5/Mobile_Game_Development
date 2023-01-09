using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text _highScore;
    [SerializeField]
    private Text _highScoreTime;
    [SerializeField]
    private Text _score;
    public int highScore;
    public string highScoreTime;
    public int scoreValue;
    public GameObject timeObject;
    public CameraShake cameraShake;

    public GameObject player;

    void Start()
    {
        //Loads the score at the start of the game
        this.LoadScore();
    }


    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Pause>().isPaused == false)
        {
            //If the game isnt paused, the score can go up
            _score.text = "Score: " + scoreValue;
            _highScore.text = "Highscore: " + highScore;
            highScoreTime = timeObject.GetComponent<WorldTimeAPI>().dates + " at " + timeObject.GetComponent<WorldTimeAPI>().times;

            if (scoreValue >= highScore)
            {
                //If the score beats the current highscore then it will overwrite the current highscore and saves it
                highScore = scoreValue;
                this.SaveScore();
            }
        }
    }

    public void AddScore(int scoreAmount)
    {
        //Adds to the score
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        scoreValue += scoreAmount;
    }

    public void SaveScore()
    {
        //Saves the score
        Debug.Log("Save Score");
        SaveSystem.saveScore(this);
    }

    public void LoadScore()
    {
        //Loads he score
        Debug.Log("Load Score");
        PlayerData data = SaveSystem.LoadScore();

        highScore = data.savedScore;
        _highScore.text = "Highscore: " + data.savedScore;
        highScoreTime = data.savedTime;
        _highScoreTime.text = "Highscore from: " + data.savedTime;
    }

    public void ResetHighScore()
    {
        //Resets the highscore
        highScore = 0;
        highScoreTime = " ";
    }
}
