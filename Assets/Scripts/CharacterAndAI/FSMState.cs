using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public class FSMState : ScriptableObject
{
    public List<FSMAction> Action = new List<FSMAction>();
    public List<FSMTransition> Transitions = new List<FSMTransition>();
    public bool RemainState = false;

    public virtual void Execute(FSMCharacter machine)
    {
        foreach (var action in Action)
        {
            Debug.Log("Execute state action: " + action);
            if (action.ExecuteOnce/* && !action.Executed*/)
            {
                if (!action.Executed)
                    action.Execute(machine);
            }
            else
            {
                action.Execute(machine);
            }
        }

        foreach (var transition in Transitions)
            transition.Execute(machine);
    }
}
