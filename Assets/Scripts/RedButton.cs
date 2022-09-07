using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    [SerializeField]
    private float maxTime = 60.0f;

    [SerializeField]
    private float minTime = 30.0f;

    [SerializeField]
    private float initialDelay = 1.0f;

    private BoxCollider bc = null;
    private MeshRenderer mr = null;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();

        bc.enabled = false;
        mr.enabled = false;

        InvokeRepeating("Warning", initialDelay, Random.Range(minTime, maxTime));
    }

    private void Warning()
    {
        bc.enabled = true;
        mr.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().RedButtonWin();

            bc.enabled = false;
            mr.enabled = false;
        }
    }
}
