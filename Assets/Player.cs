using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private int playerNumber = 1;

    private Rigidbody rb = null;

    //Custom inputs
    private string verticalAxis = "Vertical";
    private string horizontalAxis = "Horizontal";
    private string interactButton = "Interact";

    // Start is called before the first frame update
    void Start()
    {
        if(playerNumber == 2)
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

        // find one interactable object in scene
        if (Input.GetButton(interactButton))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Interactable");
            GameObject found = null;
            float range = 0.0f;

            foreach (GameObject go in gameObjects)
                if (found == null || (go.transform.position - transform.position).magnitude < range)
                {
                    found = go;
                    range = (go.transform.position - transform.position).magnitude;
                }

            if (found == null)
                Debug.Log("nothing");
            else
                Debug.Log(found.name + " found");


        }
    }
}
