using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleClass : MonoBehaviour {

    // Use this for initialization

    public bool isMobile;
    public Transform newDisc;
    public bool isLinear;
    public Vector3 Omega;
    private Vector3 velocity;
    private ParticleSystem ps;
    
    void Start () {
        //rb = GetComponent<Rigidbody>();
        ps = GameObject.FindGameObjectWithTag("blast").GetComponent<ParticleSystem>();
	}
	public void LinearMotion()
    {

    }
    public void CircularMotion() 
    {
        this.transform.LookAt(newDisc);
        Vector3 radialVector = this.transform.position - newDisc.position;
        velocity = Vector3.Cross(Omega, radialVector);
    }
    public void setParams(bool isMobile, bool isLinear, Transform newDisc)
    {
        this.isMobile = isMobile;
        this.isLinear = isLinear;
        this.newDisc= newDisc;
    }
	// Update is called once per frame
	void Update () {
		if(isMobile)
        {
            if(isLinear)
            {
                //LinearMotion();
               
            }
            else
            {
                //Debug.Log("circ");
                //CircularMotion();
              
            }
        }
	}
    private void FixedUpdate()
    {
        //transform.position += velocity * Time.deltaTime;
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        //if(other.gameObject.tag == "player")
        {
            ps.GetComponent<blastScript>().explode();
            Destroy(other.gameObject);
        }
    }
}
