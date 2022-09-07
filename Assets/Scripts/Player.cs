using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool player2 = false;

    [SerializeField]
    private float angle = 45.0f;
    [SerializeField]
    private float grabRange = 2.0f;

    [SerializeField]
    private Banana slot = null;

    //Custom inputs
    private string interactButton = "Interact";

    // Start is called before the first frame update
    void Start()
    {
        if(player2)
        {
            interactButton += "_2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Interaction
        if (Input.GetButton(interactButton))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Interactable");
            GameObject found = null;

            float minRange = grabRange;

            foreach (GameObject go in gameObjects)
            {
                float range = (go.transform.position - transform.position).magnitude;

                if (range < minRange &&
                    Vector3.Angle(transform.forward, go.transform.position - transform.position) < angle
                    && go != slot)
                {
                    found = go;
                    minRange = range;
                }
            }

            if (found != null)
            {
                Debug.Log(found.name + " found");

                slot = found.GetComponent<Items>().DoSomething(slot);

                //Grab if banana
                if(slot != null && slot.GetType() == typeof(Banana))
                {
                    Collider bananaCollider = slot.GetComponentInChildren<Collider>();
                    bananaCollider.enabled = false;
                    slot.transform.parent = this.transform;
                }
            }
        }
    }
}
