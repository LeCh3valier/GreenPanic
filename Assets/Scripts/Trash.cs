using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private GameObject Puddle = null;

    [SerializeField]
    private GameObject[] PuddlesZones;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Destroy(other.gameObject);

            int id = Random.Range(0, PuddlesZones.Length);
            Instantiate(Puddle, PuddlesZones[id].transform.position, transform.rotation);
        }
    }
}