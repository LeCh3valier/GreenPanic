using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : Items
{
    [SerializeField]
    protected bool grabed = false;

    /*public override Grabable DoSomething(Grabable slot)
    {
        //grabed = true;

        if (slot == null)
        {
            return this;
        }
        else
            return null;
}*/
}
