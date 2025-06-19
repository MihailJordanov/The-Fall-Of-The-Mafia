using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waupointIndex;
    public float waitTimer;

    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
        if(enemy.canSeePlayer())
        {
            stateMachine.changeState(new AttackState());
        }    
    }

    public override void Exit()
    {
        
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > Random.Range(1, 2)) //Random.Range(1, 3)
            {
                if (waupointIndex < enemy.path.waypoints.Count - 1)
                    waupointIndex++;
                else
                    waupointIndex = 0;
                enemy.Agent.SetDestination(enemy.path.waypoints[waupointIndex].position);
                waitTimer = 0;
            }
        }
    }

}
