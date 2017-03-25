using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour {

    // Use this for initialization
    private GameObject GameController;
	void Start () {
        GameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        
            this.gameObject.transform.LookAt((GameController.GetComponent<movePlayer>().activeDisc.transform.position + GameController.GetComponent<movePlayer>().player.transform.position) / 2);
	}
}
