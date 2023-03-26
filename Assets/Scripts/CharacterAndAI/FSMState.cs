using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One of a finite set of options indicating the current overall condition of the state-machine:
/// I'm in this state executing these actions and I may transition to other state if transitions decision conditions allow it.
/// </summary>
[CreateAssetMenu(menuName = "FSM/State")]
public class FSMState : ScriptableObject
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<FSMTransition> Transitions = new List<FSMTransition>();
    public bool RemainState = false;

    public virtual void ExecuteState(FSMCharacter machine)
    {
        //Execute all actions in this state
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

        //Execute all transitions in this state
        foreach (FSMTransition transition in Transitions)
            transition.Execute(machine);

        //There are also transitions that can happen from any state, execute them as well
        foreach (FSMTransition transition in machine.FromAnyStateTransitions)
        {
            transition.Execute(machine);
        }
    }
}
