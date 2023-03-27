using UnityEngine;

/// <summary>
/// Executed once when entering panic: set agent's destination away from EmotionalStateCausePosition (source of panic).
/// </summary>
[CreateAssetMenu(menuName = "FSM/Actions/Panicking")]
public class FSMActionPanicking : FSMAction
{
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        //Execute once.
        
        //TODO: This is quite obfuscating and not very generic or elegant way,
        //but this is how the transition can release the FSMAction Worship Interesting action's doings:
        if (stateMachine.Agent.isStopped)
        {
            stateMachine.Agent.isStopped = false;
            stateMachine.SetAnimatorBoolean("Worship", false);
        }

        //Run away from the cause of the panic.
        //TODO: Currently just hard coded 20 units away from EmotionalStateCausePosition:
        Vector3 directionAway = (stateMachine.transform.position - stateMachine.EmotionalStateCausePosition).normalized * 20f;        
        stateMachine.SetDirectAgentDestination(directionAway);
    }
}
