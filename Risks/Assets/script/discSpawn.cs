using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discSpawn : MonoBehaviour {
    public GameObject prefabDisc;
    public GameObject player;
    public GameObject linkprefab;
    public bool shifted;

    private int idKey;
    private int maxDisc=3;
    private float discDiff = 0.01f;
    private Vector3 shiftvec;

    private Vector3[] startM;
    private Vector3[] endM;
    private float startTime;
    
    private bool firstTime;
    public float speed = 1.0f;
    private float distCovered;
    private float journeyLength;
    private bool firstScore;

    // Use this for initialization
    void Start () {
        this.idKey = 0;
        GameObject disc0 = spawn();
        activateDisc(disc0);
        
        player.transform.position = new Vector3(player.transform.position.x -0.5f, player.transform.position.y, player.transform.position.z);

        firstScore = true;
        shifted = false;
        firstTime = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (shifted)
        {
            int i = 0;
            if (firstTime)
            {
                startM = new Vector3[this.gameObject.transform.childCount];
                endM = new Vector3[this.gameObject.transform.childCount];
                startTime = Time.time;
                distCovered = 0;
                journeyLength = shiftvec.magnitude;
                Debug.Log(journeyLength + " -");
                foreach (Transform child in transform)
                {
                    startM[i] = child.position;
                    endM[i] = startM[i] - shiftvec;
                    
                    i++;
                }
                firstTime = false;
            }
            i = 0;
            distCovered = (Time.time - startTime) * speed;
            Debug.Log(distCovered + " --");
            float fracJourney = distCovered / journeyLength;
            foreach (Transform child in transform)
            {
                
                child.position = Vector3.Lerp(startM[i], endM[i], fracJourney);
                i++;
            }
            if(fracJourney >= 1)
            {
                shifted = false;
            }
        }

    }

    public void activateDisc(GameObject disc)
    {
        shiftvec = Vector3.zero;
        if(GetComponent<movePlayer>().activeDisc != null)
        {
            if(GetComponent<movePlayer>().activeDisc.name.Contains("disc(Clone)0")) {
                Destroy(GetComponent<movePlayer>().activeDisc);
            }
            shiftvec = disc.transform.position - GetComponent<movePlayer>().activeDisc.transform.position;
        }
        //Debug.Log("shift "+shift.x+" "+shift.z);
        StartCoroutine(Shift(disc));
        

        
        

    }


    IEnumerator Shift(GameObject disc)
    {
        
        
        Debug.Log(Time.time + " -");
        firstTime = true;
        shifted = true;
        if (GetComponent<movePlayer>().activeDisc != null)
            GetComponent<movePlayer>().activeDisc.GetComponent<Renderer>().material.SetColor("_Color",Color.cyan);
        GetComponent<movePlayer>().activeDisc = disc;
        //GetComponent<movePlayer>().link = Instantiate(linkprefab, disc.transform.position, disc.transform.rotation, transform);

        //GetComponent<movePlayer>().link.transform.localScale = new Vector3(0.03f, 0.0001f, 0.05f);
        
        //player.transform.position = new Vector3(disc.transform.position.x - 0.5f, disc.transform.position.y + discDiff, disc.transform.position.z);

        yield return new WaitWhile(() => shifted);
        Vector3 rand = Vector3.Normalize(randSpawnVector());

        float lim = getLimit();
        float angle = Vector3.Angle(new Vector3(1, 0, 0), rand);
        
        float r = lim + (Mathf.Deg2Rad * (angle) * (GetComponent<movePlayer>().radialVel) / (20));

        //Debug.Log(" r " + rand*r);
        GameObject newDisc;
        if (!disc.GetComponent<discClass>().activatedOnce)
        {
            newDisc = spawn(rand * r, disc.transform.rotation);
            GetComponent<obstacleSpawn>().spawn(disc, newDisc);
            GetComponent<coincontroller>().spawn();
            if(!firstScore) GetComponent<scoreCounter>().incr();
        }
        firstScore = false;

        GetComponent<movePlayer>().Start();
        disc.GetComponent<discClass>().activatedOnce = true;

        GetComponent<pathCreate>().Start();
    }
    private float getLimit()
    {
        //float angle = Vector3.Angle(new Vector3(1, 0, 0), dir);

        GameObject disc = GetComponent<movePlayer>().activeDisc;
        float height = Camera.main.orthographicSize * 2;

        float a = (height * Screen.width / Screen.height) / 2 + (disc.transform.position.x);
        
        float b = height / 2 - 0.5f + disc.transform.position.z;

        float c = (height * Screen.width / Screen.height) / 2 - disc.transform.position.x;

        float d = height / 2 - 0.5f + disc.transform.position.z;

        float B = a + ((GetComponent<movePlayer>().radialVel)/(20))*(Mathf.PI/2);
        if (b<B)
        {
            B = b;
        }

        float C = B + ((GetComponent<movePlayer>().radialVel) / (20)) * (Mathf.PI / 2);
        if(C>c)
        {
            C = c;
        }

        float D = C + ((GetComponent<movePlayer>().radialVel) / (20)) * (Mathf.PI / 2);
        if (D > d)
        {
            D = d;
        }
        return D;
    }
    private Vector3 randSpawnVector()
    {
        Vector2 rand2 = Random.insideUnitCircle;
        Vector3 rand3 = new Vector3(rand2.x, 0, rand2.y);
        if(rand3.z < 0)
        {
            rand3.z = -rand3.z;
        }
         
        {
            float angle = Vector3.Angle(new Vector3(1, 0, 0), rand3);
            Debug.Log(angle);
            if(angle < 45)
            {
                rand3 = Quaternion.AngleAxis(90, Vector3.up) * rand3;
            }
            else if(angle > 135) 
            {
                rand3 = Quaternion.AngleAxis(-90, Vector3.up) * rand3;
            }
            angle = Vector3.Angle(new Vector3(1, 0, 0), rand3);
            Debug.Log(angle);

        }
        if (rand3.z < 0)
        {
            rand3.z = -rand3.z;
        }
        return rand3;
    }
    GameObject spawn(Vector3 v,Quaternion q)
    {
        GameObject disc = Instantiate(prefabDisc, v, q);
        disc.transform.parent = this.transform;
        GameObject active = GetComponent<movePlayer>().activeDisc;
        disc.transform.position = new Vector3(v.x+active.transform.position.x, 1.36f, v.z+ active.transform.position.z);
        disc.name = disc.name + idKey++;

        return disc;   
    }

    GameObject spawn()
    {
        GameObject disc = Instantiate(prefabDisc, this.transform);
        
        disc.name = disc.name+idKey++;
        return disc;
    }
}
