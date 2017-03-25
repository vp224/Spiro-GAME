using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieController : MonoBehaviour {

    // Use this for initialization
    public bool loop;
	void Start () {
        MovieTexture mov = GetComponent<Renderer>().material.mainTexture as MovieTexture;
        mov.loop = loop;
        mov.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
