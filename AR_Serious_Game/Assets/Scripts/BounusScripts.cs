using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounusScripts : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*floatSpeed);
        
    }
}
