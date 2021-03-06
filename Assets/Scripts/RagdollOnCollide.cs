using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnCollide : MonoBehaviour
{
    public BoxCollider hitCollider;
    public GameObject rig;
    public Animator animator;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;
    public bool collide;
    bool ragdolling;

    
    // Start is called before the first frame update
    void Start()
    {
        GetRagdollBits();
        RagdollOff();
    }
    private void Update()
    {
        if(!ragdolling && collide)
        {
            RagdollOn();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            collide = true;
            GameController.Instance.AddTime(2);
            GameController.Instance.UpdateScore();
            GetComponent<AudioSource>()?.Play();
            Destroy(gameObject, 8);
            GetComponent<AudioSource>().Play();
        }
    }
    public void GetRagdollBits()
    {
        ragdollColliders = rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = rig.GetComponentsInChildren<Rigidbody>();
    }
    public void RagdollOn()
    {
        animator.enabled = false;
        foreach(Collider c in ragdollColliders)
        {
            c.enabled = true;
        }
        foreach(Rigidbody r in limbsRigidbodies)
        {
            r.isKinematic = false;
        }
        hitCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void RagdollOff()
    {
        foreach (Collider c in ragdollColliders)
        {
            c.enabled = false;
        }
        foreach (Rigidbody r in limbsRigidbodies)
        {
            r.isKinematic = true;
        }
        animator.enabled = true; 
        hitCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
