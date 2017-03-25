using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadercontroller : MonoBehaviour {

    // Use this for initialization
    MovieTexture mov;
    void Start () {
        mov = GetComponent<Renderer>().material.mainTexture as MovieTexture;
    }
	
	// Update is called once per frame
	void Update () {
		if(!mov.isPlaying)
        {
            SceneManager.LoadScene("mainMenu");
        }
	}
}
