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
        float mH = Input.GetAxis(horizontalAxis);
        float mV = Input.GetAxis(verticalAxis);
        rb.velocity = new Vector3(mH * moveSpeed, rb.velocity.y, mV * moveSpeed);

        if (Input.GetButton(interactButton))
            Debug.Log("INteract player " + playerNumber);
    }
}
