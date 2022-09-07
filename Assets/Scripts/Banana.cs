using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Grabable
{
    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private Vector3[] points;
    private int indexPoint = 0;

    public override Grabable DoSomething(Grabable slot)
    {
        grabed = true;

        if (slot == null)
        {
            return this;
        }
        else
            return null;
    }

    private void Update()
    {
        if (!grabed)
        {
            if (indexPoint >= points.Length)
            {
                //Debug.Log("finished");
                return;
            }
            
            transform.position += (points[indexPoint] - transform.position).normalized * moveSpeed;

            if ((transform.position - points[indexPoint]).magnitude < 0.1f)
            {
                //Debug.Log("point reached" + indexPoint);

                indexPoint++;
            }
        }
    }
}