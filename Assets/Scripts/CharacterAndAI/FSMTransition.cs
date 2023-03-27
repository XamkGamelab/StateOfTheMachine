using UnityEngine;

/// <summary>
/// Transition handles the (possible) change of states. 
/// RemainState (bool true) is special and basically just says: don't change state.
/// </summary>
[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class FSMTransition : ScriptableObject
{
    public FSMDecision Decision;
    public FSMState TrueState;
    public FSMState FalseState;

    public void Execute(FSMCharacter stateMachine)
    {
        if (Decision.Decide(stateMachine))
        {
            if (TrueState != null)
            {
                if (TrueState.RemainState)
                    return;

                //Reset executed actions when state changes
                TrueState.Action.ForEach(action => action.SetExecuted(false));
                stateMachine.CurrentState = TrueState;
            }
            else
            {
                stateMachine.initialState.Action.ForEach(action => action.SetExecuted(false));
                stateMachine.CurrentState = stateMachine.initialState;
            }
        }
        else
        {
            if (FalseState != null)
            {
                if (FalseState.RemainState)
                    return;

                //Reset executed actions when state changes
                FalseState.Action.ForEach(action => action.SetExecuted(false));
                stateMachine.CurrentState = FalseState;
            }
            else
            {
                stateMachine.initialState.Action.ForEach(action => action.SetExecuted(false));
                stateMachine.CurrentState = stateMachine.initialState;
            }
        }
        
    }
}
