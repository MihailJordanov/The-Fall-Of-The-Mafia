using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activityState;


    public void Initialise()
    {
        changeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activityState != null)
        {
            activityState.Perform();
        }
    }

    public void changeState(BaseState newState)
    {
        if(activityState != null)
        {
            activityState.Exit();
        }

        activityState = newState;

        if(activityState != null)
        {
            activityState.stateMachine = this;
            activityState.enemy = GetComponent<Enemy>();
            activityState.Enter();
        }
    }
}
