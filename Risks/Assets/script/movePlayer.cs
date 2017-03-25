using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public bool isClicked;
    public Rigidbody player;
    //public GameObject link;
    public GameObject activeDisc;
    public float radialVel;
    public float contracVel;
    public Vector3 contractForce;
    public Vector3 Omega;

    private float r;
    private Vector3 unitRadialVector;

    private float actR;
    private float prev;
    private Vector3 prevPos;
    private float angRot;
    private Vector3 expandVel;
    private bool first;
    // Use this for initialization
    public void Start()
    {
        isClicked = false;
        unitRadialVector = new Vector3(0, 0, 1);
        prev = 0;
        prevPos = Vector3.Normalize(player.transform.position - activeDisc.transform.position);
        angRot = 0;
        first = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        if (player != null)
        {
            actR = Vector3.Distance(player.transform.position, activeDisc.transform.position);
            Vector3 radialVector = 0.5f * Vector3.Normalize(player.transform.position - activeDisc.transform.position);
            expandVel = radialVel * Vector3.Normalize(player.transform.position - activeDisc.transform.position);

            expandVel.y = 0;
            //Debug.Log(player.transform.position);
            if (isClicked)
            {
                if(first)
                    StartCoroutine(StorePos());
                if (!GetComponent<discSpawn>().shifted)
                    move(radialVector);
                first = false;

            }
        }
        //Debug.Log("----<> " + //link.transform.forward);
    
        if (player != null)
        {
            actR = Vector3.Distance(player.transform.position, activeDisc.transform.position);
            Vector3 radialVector = 0.25f * Vector3.Normalize(player.transform.position - activeDisc.transform.position);
            expandVel = contracVel * Vector3.Normalize(player.transform.position - activeDisc.transform.position);

            if (!isClicked && actR >= 0.5f)
            {
                if (!GetComponent<discSpawn>().shifted)
                    if (activeDisc.transform.position != player.transform.position)
                    {
                        //Debug.Log("fucking here");
                        //StartCoroutine(StorePos());
                        expandVel.y = 0;
                        contract(radialVector);
                    }
            }
            else if(!isClicked)
            {
                first = true;
                GetComponent<pathCreate>().Start();
                rotate(radialVector);
            }
        }
    }

    IEnumerator StorePos()
    {
        bool hereFirst = true;
        while (true)
        {
            if(hereFirst)
                GetComponent<pathCreate>().pos.AddLast(new LinkedListNode<Vector3>(player.position));
            hereFirst = false;
            yield return new WaitForSeconds(0.1f);
            if (player != null)
                GetComponent<pathCreate>().pos.AddLast(new LinkedListNode<Vector3>(player.position));
            else
                break;
            if (first)
                break;
        }
    }


    void rotate(Vector3 radialVector)
    {
        if (player != null)
        {
            angRot = Vector3.Angle(Vector3.Normalize(radialVector), prevPos);
            player.velocity = Vector3.Cross(Omega, radialVector);
            player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);

            //link.transform.position = new Vector3((player.transform.position.x + activeDisc.transform.position.x) / 2, (player.transform.position.y + activeDisc.transform.position.y) / 2,
            //    (player.transform.position.z + activeDisc.transform.position.z) / 2);
            //link.transform.localScale = new Vector3(//link.transform.localScale.x, //link.transform.localScale.y, //link.transform.localScale.z + actR - prev);
            //link.transform.LookAt(player.transform);
            //prev = actR;
            prevPos = Vector3.Normalize(radialVector);

        }
    }

    void contract(Vector3 radialVector)
    {
        if (player != null)
        {
            angRot = Vector3.Angle(Vector3.Normalize(radialVector), prevPos);
            player.velocity = Vector3.Cross(Omega, radialVector) - expandVel;
            player.velocity = new Vector3(player.velocity.x, 0, player.velocity.z);

            //link.transform.position = new Vector3((player.transform.position.x + activeDisc.transform.position.x) / 2, (player.transform.position.y + activeDisc.transform.position.y) / 2,
            //    (player.transform.position.z + activeDisc.transform.position.z) / 2);
            //link.transform.localScale = new Vector3(//link.transform.localScale.x, //link.transform.localScale.y, //link.transform.localScale.z + actR - prev);
            //link.transform.LookAt(player.transform);
            prev = actR;
            prevPos = Vector3.Normalize(radialVector);

        }
    }
    void move(Vector3 radialVector)
    {
        if (player != null)
        {

            angRot = Vector3.Angle(Vector3.Normalize(radialVector), prevPos);

            player.velocity = Vector3.Cross(Omega, radialVector) + expandVel;
            //link.transform.position = new Vector3((player.transform.position.x + activeDisc.transform.position.x) / 2,
            //                                        (player.transform.position.y + activeDisc.transform.position.y) / 2,
            //                                        (player.transform.position.z + activeDisc.transform.position.z) / 2);
            //link.transform.localScale = new Vector3(//link.transform.localScale.x,
                                                    //link.transform.localScale.y,
                                                    //link.transform.localScale.z + actR - prev);
            //link.transform.LookAt(player.transform);
            prev = actR;
            prevPos = Vector3.Normalize(radialVector);
        }
    }

}
