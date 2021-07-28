using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform barrelTransform;
    public Projectile projectile;
    public GameObject muzzleFlash;
    public int magazineCount = 0;
    public int ammoInMag { get; set; }
    public float shootSpeed = 1;

    float shootTimer;


    void Start()
    {
        ammoInMag = magazineCount;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (shootTimer <= 0)
        {
            if (ammoInMag > 0)
            {
                if (barrelTransform != null && projectile != null)
                {
                    Instantiate(projectile, barrelTransform.position, barrelTransform.rotation);
                    //ammoInMag--;
                    if (muzzleFlash != null)
                    {
                        GameObject flash = Instantiate(muzzleFlash, barrelTransform.position, barrelTransform.rotation);
                        Destroy(flash, 0.5f);
                    }
                    shootTimer = shootSpeed;
                }
            }
        }
    }

    public void Reload()
    {
        if (ammoInMag != magazineCount) ammoInMag = magazineCount;
    }
}
