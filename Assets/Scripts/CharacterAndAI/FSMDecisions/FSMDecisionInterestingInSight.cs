using UnityEngine;
using System.Linq;

/// <summary>
/// AISensor has InterestingObject in Objects.
/// </summary>
[CreateAssetMenu(menuName = "FSM/Decisions/Investigate Interesting Sighted Object")]
public class FSMDecisionInterestingInSight : FSMDecision
{
    public override bool Decide(FSMCharacter stateMachine)
    {
        AISensor sightSensor = stateMachine.GetComponent<AISensor>();

        InterestingObject firstInterestingObject = sightSensor.Objects.Select(go => go.GetComponent<InterestingObject>()).FirstOrDefault();
        return firstInterestingObject?.IsStillInteresting() ?? false;
    }
}
