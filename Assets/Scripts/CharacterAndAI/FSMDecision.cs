using UnityEngine;

/// <summary>
/// The logic establishing when a transition takes place.
/// </summary>
public abstract class FSMDecision : ScriptableObject
{
    public abstract bool Decide(FSMCharacter state);
}
