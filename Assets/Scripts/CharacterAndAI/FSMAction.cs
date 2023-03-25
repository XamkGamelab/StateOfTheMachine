using UnityEngine;

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