using UnityEngine;

public abstract class FSMDecision : ScriptableObject
{
    public abstract bool Decide(FSMCharacter state);
}
