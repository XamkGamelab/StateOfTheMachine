using UnityEngine;
using System.Linq;

/// <summary>
/// Set animation to Worship state
/// </summary>
[CreateAssetMenu(menuName = "FSM/Actions/Worship Interesting Object")]
public class FSMActionWorshipInterestingObject : FSMAction
{
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        //Execute once
        stateMachine.Agent.isStopped = true;
        stateMachine.SetAnimatorBoolean("Worship", true);
    }
}
