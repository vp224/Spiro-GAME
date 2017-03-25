using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincontroller : MonoBehaviour {

    // Use this for initialization'
    public GameObject coin;
    void Start()
    {
        spawn();
    }
	public void spawn()
    {
        float a;
        float height = Camera.main.orthographicSize ;
        float width = (height * Screen.width / Screen.height) / 2;
        if (height < width)
        {
            a = height;
        }
        else
            a = width;
        int n=Random.Range(4, 10);
        n = 1;
        for(int i=0;i<n;i++)
        {
            float x = Random.Range(-a, a);
            float y = Random.Range(-a, a);
            int r = (int)Random.Range(1, 4);
            if (x > 0 && x < 3) x = 3;
            if (y > 0 && y < 3) y = 3;
            if (x < 0 && x > -3) x = -3;
            if (y < 0 && y > -3) y = -3;

            float f = 0,g = 0;
            float w = Random.Range(0, 5);
            if (w < 2)
            {
                for (int j = 0; j < r; j++)
                {

                    for (int k = 0; k < r; k++)
                    {
                        Instantiate(coin, new Vector3(x + f, 1.37f, y + g), coin.transform.rotation, this.transform);
                        f = f + 1;
                        // Debug.Log("sk " + f + " " + g+" " +r);
                    }
                    g = g + 1;
                    f = 0;
                }
            }
            else
            {
                for (int j = 0; j < r; j++)
                {


                    Instantiate(coin, new Vector3(x + f, 1.37f, y + g), coin.transform.rotation, this.transform);
                    f = f + 0.5f;
                    g = g + 0.5f;
                    // Debug.Log("sk " + f + " " + g+" " +r);
                }
            }
            // Instantiate(coin, new Vector3(x, 1.37f,  y), coin.transform.rotation, this.transform);
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
