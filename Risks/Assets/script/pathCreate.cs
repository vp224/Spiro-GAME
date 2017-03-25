using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathCreate : MonoBehaviour {

    // Use this for initialization
    public LinkedList<Vector3> pos;
    public GameObject playerPrefab;
    private float diff;
    public void Start()
    {
        pos = new LinkedList<Vector3>();
        diff = 50;
    }
    public void create()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        int i = 0;
        foreach (Vector3 marker in pos)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject mark = Instantiate(playerPrefab, marker, playerPrefab.transform.rotation);
        }
    }
}
