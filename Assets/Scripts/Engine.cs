using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Items
{
    [SerializeField]
    private Items finalProduct = null;

    [SerializeField]
    private float craftingTime = 5.0f;

    private float remainingTime = -1.0f;
    private bool produce = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (produce)
        {
            if (remainingTime < 0.0f)
            {
                Debug.Log("cooked !");

                produce = false;

                Instantiate(finalProduct, transform.position + new Vector3(1.0f, 0.0f, 0.0f), transform.rotation);
            }
            else
            {
                remainingTime -= Time.deltaTime;
                //Debug.Log("remaining tim : " + remainingTime);
            }
        }
    }

    public override Grabable DoSomething(Grabable slot)
    {
        if (slot != null && !produce)
        {
            Debug.Log("Strat cooking");
            produce = true;
            remainingTime = craftingTime;
            Destroy(slot.gameObject);
            return null;
        }
        else
            return slot;
    }
}

