using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discClass : MonoBehaviour {

    public int id;
    public GameObject linkprefab;
    private GameObject GameController;
    private GameObject player;
    public bool activatedOnce;
    // Use this for initialization
	void Start () {
        id = 0;
        player = GameObject.FindGameObjectWithTag("player");
        GameController = GameObject.FindGameObjectWithTag("GameController");
        activatedOnce = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {

    }



    void OnTriggerEnter(Collider other)
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        //Debug.Log(other.name);
        if(other.gameObject.name.Contains("obstacle"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "player" && this.gameObject.name!= GameController.GetComponent<movePlayer>().activeDisc.name)
        {
            //Debug.Log("up here man");
            //Destroy(GameController.GetComponent<movePlayer>().link);
            GameController.GetComponent<discSpawn>().activateDisc(this.gameObject);
           

        }
       
        else if (other.gameObject.tag == "link")
        {
            Destroy(player);

            //Debug.Log("Game Over");
        } 
    }
}
