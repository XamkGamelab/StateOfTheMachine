using UnityEngine;

/// <summary>
/// What stuff we do in a certain state? State can also be executed once, 
/// which is ok, since it doesn't have to contribute to a change of state at all.
/// </summary>
public abstract class FSMAction : ScriptableObject, ISerializationCallbackReceiver
{
    public bool ExecuteOnce = false;
    
    [System.NonSerialized]
    public bool IsExecuted = false;
    
    public virtual void Execute(FSMCharacter stateMachine)
    {
        if (ExecuteOnce)
            IsExecuted = true;
    }

    public void SetExecuted(bool isExecuted)
    {
        IsExecuted = isExecuted;
    }

    public void OnAfterDeserialize()
    {
        IsExecuted = false;
    }

    public void OnBeforeSerialize() { }
}