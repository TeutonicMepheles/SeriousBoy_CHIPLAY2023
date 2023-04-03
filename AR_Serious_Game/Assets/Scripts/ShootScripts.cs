using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScripts : MonoBehaviour
{
    public GameObject arCamera; 

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(arCamera.transform.position,arCamera.transform.forward,out hit))
        {
            if (hit.transform.name == "shootspawn1(Clone)" || hit.transform.name == "shootspawn2(Clone)" ||
                hit.transform.name == "shootspawn3(Clone)")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
