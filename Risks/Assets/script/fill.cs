using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        this.transform.localScale = new Vector3(height * Screen.width / Screen.height, height, 1);
    }
    void Update()
    {
        float height = Camera.main.orthographicSize * 2;
        this.transform.localScale = new Vector3(height*Screen.width/Screen.height, height, 1);
    }
}
