using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if(enemy.canSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;

            enemy.transform.LookAt(enemy.Player.transform);

            if(shootTimer > enemy.fireRate)
            {
                Shoot();
            }

            // move enemy to a random position after a random time
            if (moveTimer > Random.Range(4, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            // remeber last seen player position
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else // lost sight of player
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 3)
            {
                // change to the searchState
                stateMachine.changeState(new SearchState());
            }
        }
    }
    
    public void Shoot()
    {

        Transform gunbarrel = enemy.gunBarrel;

        //Resources.Load("Prefabs/Bullet") as GameObject
        GameObject bullet = GameObject.Instantiate(enemy.bullet, gunbarrel.position, enemy.transform.rotation);

        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;


        // -3f, 3f        * 40   !!!!!!!!!!!!!
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-0.5f, 0.5f), Vector3.up) * shootDirection * 60;
        shootTimer = 0; 
    }
}
