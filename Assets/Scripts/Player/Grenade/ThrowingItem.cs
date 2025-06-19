using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingItem : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public PlayerItems plItems;
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow = true;

    void Start()
    {
        plItems = GetComponent<PlayerItems>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Throw();
        }
    }

    public void Throw()
    {
        if (readyToThrow && plItems.grenadeCount > 0)
        {
            readyToThrow = false;


            // instantie object to throw
            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

            // get rigitbody component
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();



            // add force
            Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;



            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            plItems.grenadeCount--;

            // implement throwCooldown
            Invoke(nameof(ResetThrow), throwCooldown);
        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    

}

