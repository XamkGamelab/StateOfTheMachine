using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[CreateAssetMenu(menuName = "FSM/Actions/Sight Interesting Object")]
public class FSMActionInterestingObject : FSMAction
{
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);

        AISensor enemySightSensor = stateMachine.GetComponent<AISensor>();
        GameObject firstObject = enemySightSensor.Objects.FirstOrDefault();        
        stateMachine.SetDirectAgentDestination(firstObject.transform.position);
    }
}
