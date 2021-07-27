using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Gun sniper;

    void Start()
    {
        
    }

    void Update()
    {
        float rTriggerTouch = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool reload = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch);

        if (rTriggerTouch > 0.1f)
        {
            sniper?.Shoot();
        }
        else if (reload)
        {
            sniper?.Reload();
        }

    }
}
