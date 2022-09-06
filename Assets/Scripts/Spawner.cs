using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject banana = null;

    [SerializeField]
    private float spawnDelay = 1.0f;
    [SerializeField]
    private float spawnTime = 1.0f;

    private bool spawning = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    private void SpawnObject()
    {
        Instantiate(banana, transform.position, transform.rotation);
        if (!spawning)
            CancelInvoke("SpawnObject");
    }
}
