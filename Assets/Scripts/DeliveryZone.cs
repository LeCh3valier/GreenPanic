using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryZone : Items
{
    private int gold = 0;

    public override void DoSomething(GameObject slot)
    {
        if (slot == null)
            return;

        if (slot.GetComponent<ConveyorMovement>() == null)
        {
            gold += 1;
            Debug.Log("GOLD : " + gold);
            Destroy(slot.gameObject);
        }
    }
}
