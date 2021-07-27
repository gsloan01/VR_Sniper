using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Projectile projectile;
    public int magazineCount = 0;
    public int ammoInMag = 0;


    void Start()
    {
        ammoInMag = magazineCount;
    }

    void Update()
    {
        
    }

    public void Shoot()
    {

    }

    public void Reload()
    {
        if (ammoInMag != magazineCount) ammoInMag = magazineCount;
    }
}
