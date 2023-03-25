using UnityEngine;

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
            //TrueState and falseState to simply FSMState instead of base state.
            //
            stateMachine.CurrentState = TrueState;
        }
        else if (!FalseState.RemainState)
        {
            stateMachine.CurrentState = FalseState;
        }
    }
}
