using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject Player;
    public float speed = 2.0f;
    void Start()
    {
        Ragdoll(true);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void Ragdoll(bool value)
    {
        var bodyParts = GetComponentsInChildren<Rigidbody>();
        foreach (var bodyPart in bodyParts)
        {
            bodyPart.isKinematic = value;
        }
    }

    void Run()
    {
        transform.LookAt(Player.gameObject.transform);
        GetComponent<Animator>().SetTrigger("Move");
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void KillZombie(RaycastHit hitLocationInfo)
    {
        GetComponent<Animator>().enabled = false;
        Ragdoll(false);
        Vector3 hitPoint = hitLocationInfo.point;

        var colliders = Physics.OverlapSphere(hitPoint, 0.5f);

        foreach (var collider in colliders)
        {
            var rigidBody = collider.GetComponent<Rigidbody>();
            if(rigidBody)
            {
                rigidBody.AddExplosionForce(1000, hitPoint, 0.5f);
            }
        }
        this.enabled = false;
    }
}
