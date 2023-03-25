using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public class FSMState : ScriptableObject
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<FSMTransition> Transitions = new List<FSMTransition>();
    public bool RemainState = false;

    public virtual void ExecuteState(FSMCharacter machine)
    {
        foreach (FSMAction action in Action)
        {
            
            if (action.ExecuteOnce)
            {
                if (!action.IsExecuted)                
                    action.Execute(machine);
            }
            else
            {
                action.Execute(machine);
            }
        }

        foreach (FSMTransition transition in Transitions)
            transition.Execute(machine);

        foreach (FSMTransition transition in machine.FromAnyStateTransitions)
        {
            transition.Execute(machine);
        }
    }
}
