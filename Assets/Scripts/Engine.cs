using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Items
{
    [SerializeField]
    private Items finalProduct = null;
    
    [SerializeField]
    private float craftingTime = 5.0f;

    [SerializeField]
    private GameObject cookingPlace = null;

    private float remainingTime = -1.0f;
    private bool produce = false;

    // Update is called once per frame
    void Update()
    {
        if (produce)
        {
            if (remainingTime < 0.0f)
            {
                produce = false;

                Instantiate(finalProduct, cookingPlace.transform.position, transform.rotation);
            }
            else
                remainingTime -= Time.deltaTime;
        }
    }

    public override void DoSomething(GameObject slot, bool playerSide)
    {
        if (slot != null && !produce)
        {
            produce = true;
            remainingTime = craftingTime;
            Destroy(slot.gameObject);
        }
    }
}

