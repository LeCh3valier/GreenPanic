using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool player2 = false;

    //[SerializeField]
    //private float angle = 45.0f;
    //[SerializeField]
    //private float grabRange = 2.0f;

    //[SerializeField]
    //private Grabable slot = null;

    //[SerializeField]
    //private GameObject grabPoint;

    //Custom inputs
    //private string interactButton = "Interact";

    //private BoxCollider bc = null;

    // Start is called before the first frame update
    void Start()
    {
        //if(player2)
        //{
        //    interactButton += "_2";
        //}
        //
        //bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Interaction
        /*if (Input.GetButton(interactButton))
        {
            Collider[] colliders = Physics.OverlapBox(bc.transform.position, bc.transform.localScale);

            //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Interactable");
            GameObject found = null;

            foreach (Collider co in colliders)
            {
                if (
                    co != slot
                    && co.gameObject.tag == "Interactable"
                    )
                {
                    found = co.gameObject;
                }
            }

            if (found != null)
            {
                Debug.Log(found.name + " used");

                slot = found.GetComponent<Items>().DoSomething(slot);

                //Grab if banana
                if (slot != null && slot.GetComponents<Grabable>() != null)
                {
                    Debug.Log("grabed : " + found.name);

                    Collider bananaCollider = slot.GetComponentInChildren<Collider>();
                    if (bananaCollider != null)
                    {
                        bananaCollider.enabled = false;
                        slot.transform.parent = this.transform;
                        slot.transform.position = grabPoint.transform.position;
                    }
                }
            }
        }*/
    }

    public void RedButtonWin()
    {
        Debug.Log(this.name + "walked on the red button first");
        // do redButton win consequences
    }
}