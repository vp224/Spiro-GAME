using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour {
    public ParticleSystem ps;
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        this.transform.localScale = new Vector3(0.07f, this.transform.localScale.y, height);
        this.transform.position = new Vector3(-(height * Screen.width / Screen.height )/2, this.transform.localScale.y, 0);
    }
    void Update()
    {
        float height = Camera.main.orthographicSize * 2;
        this.transform.localScale = new Vector3(0.07f, this.transform.localScale.y, height );
        this.transform.position = new Vector3(-(height * Screen.width / Screen.height) / 2, this.transform.localScale.y, 0);
    }
    void OnTriggerExit(Collider other)
    {
        

        if (other.gameObject.tag != "obstacle")
        {
            ps.GetComponent<blastScript>().explode();
            Destroy(other.gameObject);
        }
    }
}
