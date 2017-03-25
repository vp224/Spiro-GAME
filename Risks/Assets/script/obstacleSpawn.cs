using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawn : MonoBehaviour {

    // Use this for initialization
    public GameObject prefab1;
    public GameObject prefab2;
    private bool isMobile;
    private bool isLinear;
    private float zpos;
    private float xpos;
    private float whichPrefab;
    private float spawnOrNot;

    void Start () {
		
	}
	public void spawn(GameObject activeDisc,GameObject newDisc)
    {
        float limits=Mathf.Abs(activeDisc.transform.position.z - newDisc.transform.position.z - 1);

        if(limits>3 && GetComponent<scoreCounter>().getScore()>=50)
        {
            GameObject obstacle;
            choseObstacleParam(activeDisc.transform.position.z+1,newDisc.transform.position.z-1);
            if (spawnOrNot > 0.2f)
            {
                if (whichPrefab > 0.5f)
                {

                    obstacle = Instantiate(prefab1, activeDisc.transform.position + new Vector3(xpos + 1, 0, zpos + 1f), Quaternion.identity, this.gameObject.transform);

                    //Debug.Log(activeDisc.transform.position + " " + xpos + " " + zpos + " " + activeDisc.transform.position + new Vector3(xpos, 0, zpos));
                }
                else
                {

                    obstacle = Instantiate(prefab2, activeDisc.transform.position + new Vector3(xpos + 1, 0, zpos + 1), Quaternion.identity, this.gameObject.transform);

                    //Debug.Log(obstacle.transform.position);
                }
                obstacle.GetComponent<obstacleClass>().setParams(isMobile, isLinear, newDisc.transform);
            }
        }
    }
    public void choseObstacleParam(float a,float b)
    {
        whichPrefab = (whichPrefab+1)%2;

        spawnOrNot = Random.value;
        float isMobile = 1;
        
        if(isMobile >0.5f)
        {
            this.isMobile = true;
           
        }
        else
        {
            this.isMobile = false;
            
        }
        float isLinear = 0;
        if(isLinear > 0.5f)
        {
            this.isLinear = true;
             
        }
        else
        {
            this.isLinear = false;
            
        }
        zpos = Random.Range(0, b-a);
        //Debug.Log("zpos : " + zpos);
        float height = Camera.main.orthographicSize * 2;
        float limrange=height* Screen.width / Screen.height*5/ 10;
        float lims = limrange / 2;
        xpos = Random.Range(-lims, lims);



    }
	// Update is called once per frame
	void Update () {
		
	}
}
