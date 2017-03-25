using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickDet : MonoBehaviour {
    GameObject GameController;
    // Use this for initialization
    void Start () {
        GameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
                GameController.GetComponent<movePlayer>().isClicked = true;
            //Debug.Log("here");
        }
        if(Input.GetMouseButtonUp(0))
        {
            GameController.GetComponent<movePlayer>().isClicked = false;
            //Debug.Log("here1");
        }
	}
}
