using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class FSMActionPatrol : FSMAction
{
    public float CloseEnoughDistance = 0.5f;
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        
        if (!stateMachine.Agent.hasPath || stateMachine.Agent.remainingDistance < CloseEnoughDistance)
        {
            stateMachine.SetNextPatrolPointDestination();
        }
    }
}
