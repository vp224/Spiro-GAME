using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastScript : MonoBehaviour {
    private ParticleSystem ps;
    public GameObject player;
    public GameObject quad;
    public GameObject gameController;
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;
    }
    public void explode()
    {
        var em = ps.emission;
        em.enabled = true;
        StartCoroutine(Example());
        
    }
    void FixedUpdate()
    {
        if(player != null) this.transform.position = player.transform.position;
    }
    IEnumerator Example()
    {
        var em = ps.emission;
        print(Time.time);
        yield return new WaitForSeconds(0.47f);
        em.enabled = false;
        print(Time.time);

        gameController.GetComponent<pathCreate>().create();
        quad.GetComponent<sceneController>().GameOver();
    }
}
