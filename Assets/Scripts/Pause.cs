using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Pause : MonoBehaviour
{

    //[EventRef] public string MyEvent;
    //[ParamRef] public string MyRTPC;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PauseButton"))
        {
            Debug.Log("pause");
            //RuntimeManager.PlayOneShot(MyEvent);
            //RuntimeManager.StudioSystem.setParameterByName(MyRTPC, 100);
        }

        if (Input.GetButton("PauseButton_2"))
            Debug.Log("pause 2");

        if (Input.GetButton("Interact"))
            Debug.Log("Interact");

        if (Input.GetButton("Interact_2"))
        {
            Debug.Log("Interact_2");

        }

    }
}
