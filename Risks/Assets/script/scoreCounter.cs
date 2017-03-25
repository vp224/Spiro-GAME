using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour {

    // Use this for initialization

    private int score;
    public Text scoreDisp;
    private int newScore;
    public int highscore;
    //public Text text;
    public Text hscoreDisp;
    public void incr()
    {

        newScore += 10;
    }
    public int getScore()
    {
        return score;
    }
	void Start () {
        
        score = 0;
        highscore = 0;
        newScore = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(getScore());
        scoreDisp.text = score.ToString();

		if(newScore>0)
        {
            score++;newScore--;
        }

        if (score > highscore)
            highscore = score;
        
       PlayerPrefs.SetInt("highscore", highscore);

        hscoreDisp.text = "High Score : "+highscore.ToString();
    }
}
