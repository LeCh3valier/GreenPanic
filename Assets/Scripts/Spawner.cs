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
    private float accelerationDelay = 30.0f;
    [SerializeField]
    private float accelerationValue = 1.0f;
    [SerializeField]
    private float minDelay = 1.0f;

    private float accelerationTimer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);

        accelerationTimer = 0.0f;
    }

    private void Update()
    {
        accelerationTimer += Time.deltaTime;
    }

    // Update is called once per frame
    private void SpawnObject()
    {
        // Make spawn
        Instantiate(banana, transform.position, transform.rotation);

        // Faster
        if (accelerationTimer > accelerationDelay)
        {
            accelerationTimer = 0.0f;

            spawnDelay -= accelerationValue;
            if (spawnDelay < minDelay)
                spawnDelay = minDelay;

            CancelInvoke("SpawnObject");
            InvokeRepeating("SpawnObject", spawnDelay, spawnDelay);
        }
    }
}
