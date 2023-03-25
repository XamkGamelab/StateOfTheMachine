using UnityEngine;

public abstract class FSMAction : ScriptableObject
{
    public bool ExecuteOnce = false;

    public bool Executed { get; private set; } = false;
    public virtual void Execute(FSMCharacter stateMachine)
    {
        if (ExecuteOnce)
            Executed = true;
    }

    public void SetExecuted(bool isExecuted)
    {
        Executed = isExecuted;
    }
}