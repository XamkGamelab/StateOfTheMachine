using UnityEngine;
using System.Linq;

/// <summary>
/// Set agent destination (once) to InterestingObject position.
/// </summary>
[CreateAssetMenu(menuName = "FSM/Actions/Sight Interesting Object")]
public class FSMActionInterestingObject : FSMAction
{
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        //Execute once
        AISensor enemySightSensor = stateMachine.GetComponent<AISensor>();
        GameObject firstObject = enemySightSensor.Objects.FirstOrDefault();        
        stateMachine.SetDirectAgentDestination(firstObject.transform.position);
    }
}
