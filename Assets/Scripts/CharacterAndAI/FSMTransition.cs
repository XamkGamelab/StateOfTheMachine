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
        if (Decision.Decide(stateMachine) && !TrueState.RemainState)
        {
            //Reset executed actions when state changes
            TrueState.Action.ForEach(action => action.SetExecuted(false));
            stateMachine.CurrentState = TrueState;
        }
        else if (!FalseState.RemainState)
        {
            //Reset executed actions when state changes
            TrueState.Action.ForEach(action => action.SetExecuted(false));
            stateMachine.CurrentState = FalseState;
        }
    }
}
