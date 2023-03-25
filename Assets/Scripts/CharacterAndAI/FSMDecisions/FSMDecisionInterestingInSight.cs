using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "FSM/Decisions/Investigate Interesting Sighted Object")]
public class FSMDecisionInterestingInSight : FSMDecision
{
    public override bool Decide(FSMCharacter stateMachine)
    {
        AISensor enemySightSensor = stateMachine.GetComponent<AISensor>();

        InterestingObject firstInterestingObject = enemySightSensor.Objects.Select(go => go.GetComponent<InterestingObject>()).FirstOrDefault();
        return firstInterestingObject?.IsStillInteresting() ?? false;
    }
}
