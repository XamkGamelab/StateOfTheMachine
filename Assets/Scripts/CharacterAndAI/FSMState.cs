using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class FSMState : FSMBaseState
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<FSMTransition> Transitions = new List<FSMTransition>();

    public override void Execute(FSMCharacter machine)
    {
        foreach (var action in Action)
        {
            if (action.ExecuteOnce && !action.Executed)
                action.Execute(machine);
        }

        foreach (var transition in Transitions)
            transition.Execute(machine);
    }
}
