using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine : Items
{
    public override Banana DoSomething(Banana slot)
    {
        Debug.Log("Machine used !");
        return null;
    }
}
