using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Transition")]
public sealed class FSMTransition : ScriptableObject
{
    public FSMDecision Decision;
    public FSMBaseState TrueState;
    public FSMBaseState FalseState;

    public void Execute(FSMCharacter stateMachine)
    {
        if (Decision.Decide(stateMachine) && !(TrueState is FSMRemainState))
        {
            //TrueState and falseState to simply FSMState instead of base state.
            //
            stateMachine.CurrentState = TrueState;
        }
        else if (!(FalseState is FSMRemainState))
        {
            stateMachine.CurrentState = FalseState;
        }
    }
}
