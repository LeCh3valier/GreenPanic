using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;

    public int factor = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (0.0f, 0.0f, moveSpeed * factor * Time.deltaTime);
    }
}
