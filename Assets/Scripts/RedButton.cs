using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class RedButton : MonoBehaviour
{

    FMODUnity.StudioEventEmitter emitter;
    private float soundState = 0.0f;

    [SerializeField]
    private float minTime = 30.0f;
    [SerializeField]
    private float maxTime = 60.0f;

    [SerializeField]
    private float initialMin = 30.0f;
    [SerializeField]
    private float initialMax = 60.0f;

    private BoxCollider bc = null;
    private MeshRenderer mr = null;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();

        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();

        bc.enabled = false;
        mr.enabled = false;

        InvokeRepeating("Warning", Random.Range(initialMin, initialMax), Random.Range(minTime, maxTime));
    }

    private void Warning()
    {
        bc.enabled = true;
        mr.enabled = true;

        // Do red button fxs and play music
        emitter.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().RedButtonWin();

            bc.enabled = false;
            mr.enabled = false;

            // stop red button music and fxs
            emitter.Stop();
        }
    }
}
