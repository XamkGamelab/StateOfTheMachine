using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class FSMTransition : ScriptableObject, ISerializationCallbackReceiver
{
    public FSMDecision Decision;
    public FSMState TrueState;
    public FSMState FalseState;
    
    [System.NonSerialized]
    private FSMState previousState = null;

    public void Execute(FSMCharacter stateMachine)
    {
        if (Decision.Decide(stateMachine) && !TrueState.RemainState)
        {
            //Prevent transition to same state
            if (TrueState != previousState)
            {
                //Reset executed actions when state changes
                TrueState.Action.ForEach(action => action.SetExecuted(false));
                previousState = stateMachine.CurrentState = TrueState;
            }       
        }
        else if (!FalseState.RemainState)
        {
            //Prevent transition to same state
            if (FalseState != previousState)
            {
                //Reset executed actions when state changes
                TrueState.Action.ForEach(action => action.SetExecuted(false));
                previousState = stateMachine.CurrentState = FalseState;
            }
        }
    }

    public void OnAfterDeserialize()
    {
        previousState = null;
    }

    public void OnBeforeSerialize() { }
}
