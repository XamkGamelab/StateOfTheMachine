using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decisions/IsInterested")]
public class FSMDecisionIsInterested : FSMDecision
{
    public override bool Decide(FSMCharacter stateMachine)
    {
        return stateMachine.CurrentEmotionalState == FSMCharacter.EmotionalState.Interested;
    }
}
