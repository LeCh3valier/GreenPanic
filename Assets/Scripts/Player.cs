using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private bool player2 = false;

    [SerializeField]
    private float angle = 45.0f;
    [SerializeField]
    private float grabRange = 2.0f;

    [SerializeField]
    private Banana slot = null;

    private Rigidbody rb = null;

    //Custom inputs
    private string verticalAxis = "Vertical";
    private string horizontalAxis = "Horizontal";
    private string interactButton = "Interact";

    // Start is called before the first frame update
    void Start()
    {
        if(player2)
        {
            verticalAxis += "_2";
            horizontalAxis += "_2";
            interactButton += "_2";
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float mH = Input.GetAxis(horizontalAxis);
        float mV = Input.GetAxis(verticalAxis);
        rb.velocity = new Vector3(mH * moveSpeed, rb.velocity.y, mV * moveSpeed);

        // Turn
        if(rb.velocity != Vector3.zero)
        {
            transform.forward = rb.velocity;
        }

        // Find or not one interactable object in scene
        if (Input.GetButton(interactButton))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Interactable");
            GameObject found = null;

            float minRange = grabRange;

            foreach (GameObject go in gameObjects)
            {
                float range = (go.transform.position - transform.position).magnitude;

                if (range < minRange &&
                    Vector3.Angle(transform.forward, go.transform.position - transform.position) < angle)
                {
                    found = go;
                    minRange = range;
                }
            }

            if (found == null)
                return;
                //Debug.Log("nothing grabed");
            else
            {
                Debug.Log(found.name + " found");

                slot = found.GetComponent<Items>().DoSomething(slot);
            }
        }
    }
}
