using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    public void fadeIn()
    {
        Color color = rend.material.color;
        color.a += 0.2f;
        rend.material.color = color;
    }
}
