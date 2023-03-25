using UnityEngine;

public class FSMBaseState : ScriptableObject
{
    public virtual void Execute(FSMCharacter machine) { }
}
