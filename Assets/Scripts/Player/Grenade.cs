using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float startTimer = 0f;

    [Header("Stats")]
    public float exposionRadius = 5f;
    public float damage = 100f;
    public float exposionCooldown = 3f;

    [Header("Impact Effect")]
    public GameObject impactEffect;






    // Start is called before the first frame update
    void Start()
    {
        startTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if(startTimer >= exposionCooldown)
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 3f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, exposionRadius);
        foreach (Collider collider in colliders)
        {
            Enemy enemy = collider.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exposionRadius);
    }
}
