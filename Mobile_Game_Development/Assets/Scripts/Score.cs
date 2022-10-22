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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Pause>().isPaused == false)
        {
            scoreValue += 1;
            _score.text = "Score: " + scoreValue;
        }
    }
}
