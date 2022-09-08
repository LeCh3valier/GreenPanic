using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class soundDestroyer : MonoBehaviour
{
    [SerializeField]
    private float stat = 0.0f;

    FMODUnity.StudioEventEmitter emitter;

    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("Game State", stat);

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Game State", stat);

        if (Input.GetButtonDown("Interact"))
        {
            if(emitter.IsPlaying())
            {
                emitter.Stop();
            }
            else
            {
                emitter.Play();
            }
        }
    }
}
