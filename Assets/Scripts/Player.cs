using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool player2 = false;

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private Vector2 Padthrehold = new Vector3(0.5f, 0.5f);

    //private Grabable slot = null;

    [SerializeField]
    private GameObject grabPoint;

    //Custom inputs
    private string interactButton = "Interact";
    private string hAxis = "Horizontal";
    private string vAxis = "Vertical";

    private Rigidbody rigidBody = null;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        if (player2)
        {
            interactButton += "_2";
            hAxis += "_2";
            vAxis += "_2";
        }

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Interact();
    }

    public void RedButtonWin()
    {
        Debug.Log(this.name + "walked on the red button first");
        // do redButton win consequences
    }

    private void Move()
    {
        // Get imputs
        float moveY = Input.GetAxisRaw(hAxis);
        if (Mathf.Abs(moveY) < Padthrehold.y)
            moveY = 0.0f;

        float moveX = Input.GetAxisRaw(vAxis);
        if (Mathf.Abs(moveX) < Padthrehold.x)
            moveX = 0.0f;

        // Set animation
        if (animator != null )
            if(rigidBody.velocity != Vector3.zero)
                animator.SetBool("Run", true);
            else
                animator.SetBool("Run", false);

        // Move
        rigidBody.velocity = new Vector3(moveSpeed * moveX, 0.0f, moveSpeed * moveY);

        // Set forward
        if (rigidBody.velocity != Vector3.zero)
        {
            gameObject.transform.forward = rigidBody.velocity;
        }
    }

    private void Interact()
    {
        /*
       // Interaction
       if (Input.GetButton(interactButton))
       {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetType() == typeof(Items))
        {

        }
    }
}