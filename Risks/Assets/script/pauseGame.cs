using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {

    // Use this for initialization
    private Rigidbody player;
    private Vector3 prevVelocity;
    public bool pauseActive;
    public Button button;

    void Start()
    {
        player = GetComponent<movePlayer>().player;
        pauseActive = true;
    }
    public void PauseorResume()
    {
        //Debug.Log("clicked in pause");
        if (pauseActive)
        {
            prevVelocity = player.velocity;
            GetComponent<movePlayer>().enabled = false;
            player.velocity = Vector3.zero;
            button.GetComponent<changePausetoResume>().changetoResume();
            pauseActive = !pauseActive;
        }
        else
        {
            GetComponent<movePlayer>().enabled = true;
            player.velocity = prevVelocity;
            button.GetComponent<changePausetoResume>().changetoPause();
            pauseActive = !pauseActive;
        }
    }
}
