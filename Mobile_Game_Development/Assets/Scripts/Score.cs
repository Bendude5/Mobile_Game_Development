using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text _highScore;
    [SerializeField]
    private Text _score;
    public int highScore;
    public int scoreValue;
    public CameraShake cameraShake;

    public GameObject player;

    void Start()
    {
        this.LoadScore();
    }


    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Pause>().isPaused == false)
        {
            _score.text = "Score: " + scoreValue;
            _highScore.text = "Highscore: " + highScore;

            if (scoreValue >= highScore)
            {
                highScore = scoreValue;
                this.SaveScore();
            }
        }
    }

    public void AddScore(int scoreAmount)
    {
        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
        scoreValue += scoreAmount;
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

        highScore = data.savedScore;
        _highScore.text = "Highscore: " + data.savedScore;
    }

    public void ResetHighScore()
    {
        highScore = 0;
    }
}
