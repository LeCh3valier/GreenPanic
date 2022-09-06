using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Items
{
    [SerializeField]
    private bool grabed = false;

    [SerializeField]
    private float moveSpeed = 0.0001f;

    public override void DoSomething()
    {
        //Debug.Log("grabed pnt samere un peu");

        grabed = true;
        Debug.Log("grabed pnt samere");
        
    }

    private void Update()
    {
        if(!grabed)
        {
            transform.position += Vector3.forward * moveSpeed;
        }
    }
}