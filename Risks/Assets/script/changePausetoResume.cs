using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePausetoResume : MonoBehaviour {

	// Use this for initialization
    public Sprite pauseImage;
    public Sprite resumeImage;
    
    public void changetoPause ()
    {
        GetComponent<Image>().sprite = pauseImage;
    }
    public void changetoResume()
    {
        GetComponent<Image>().sprite = resumeImage;
    }
}
