using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnowPos;

    //MINE
    private float health;
    private bool isDead = false;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }

    public float worth = 5;
    public float expWorth = 5;
    public Path path;

    [Header("Sound Effect")]
    public AudioSource src;
    public AudioClip soundEffect;

   
    //MINE
    [Header("Health")]
    public float startHealth = 100;
    public Image healthBar;
    public GameObject deathEffect;

    [Header("Sight Value")]
    public float sightDistance = 20f;
    public float fielOfView = 85f;
    public float eyeHight;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10)]
    public float fireRate;
    public GameObject bullet;

    [SerializeField]
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");

        //MINE
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer();
        currentState = stateMachine.activityState.ToString();  
    }

    public bool canSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHight);
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angelToPlayer >= -fielOfView && angelToPlayer <= fielOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }


    //MINE
    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            die();
        }
    }

    void die()
    {
        isDead = true;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Stats.JewsKills += 1;
        Stats.Exp += expWorth;
        Stats.Money += worth;
        src.clip = soundEffect;
        src.Play();

        Destroy(gameObject);
    }

}
