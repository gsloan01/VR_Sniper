using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject bloodSplatter;
    public GameObject dustSplatter;
    public float speed = 5;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb?.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject effect = dustSplatter;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (bloodSplatter != null) effect = bloodSplatter;
        }

        if (effect != null)
        {
            GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
        }
        Destroy(gameObject, 0.5f);
    }
}
