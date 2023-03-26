using UnityEngine;

/// <summary>
/// Is character's EmotionalState Default.
/// </summary>
[CreateAssetMenu(menuName = "FSM/Decisions/Emotion: Feeling default much?")]
public class FSMDecisionEmotionFeelingDefault : FSMDecision
{
    public override bool Decide(FSMCharacter stateMachine)
    {
        return stateMachine.CurrentEmotionalState == FSMCharacter.EmotionalState.Default;
    }
}