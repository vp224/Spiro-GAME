using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	// Update is called once per frame
        void OnTriggerEnter(Collider other)
    {
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
            if (other.gameObject.CompareTag("coin"))
            {
                Destroy(other.gameObject);
                GameController.GetComponent<scoreCounter>().incr();
                //Debug.Log(GameController.GetComponent<scoreCounter>().getScore());
            }
        }
    }

