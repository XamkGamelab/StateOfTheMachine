using UnityEngine;

/// <summary>
/// Is character's EmotionalState Panic?
/// </summary>
[CreateAssetMenu(menuName = "FSM/Decisions/Emotion: Panic?")]
public class FSMDecisionEmotionPanic : FSMDecision
{
    public override bool Decide(FSMCharacter stateMachine)
    {
        return stateMachine.CurrentEmotionalState == FSMCharacter.EmotionalState.Panic;
    }
}