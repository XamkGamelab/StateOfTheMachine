using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FSMCharacter : NavMeshAgentCharacter
{
    [SerializeField, Tooltip("State from which the AI starts executing next states depending on decisions.")] 
    private FSMState initialState;
    [Tooltip("Transitions that are allowed from any state.")]
    public List<FSMTransition> FromAnyStateTransitions = new List<FSMTransition>();

    [ReadOnly, Tooltip("Current state for debugging.")] 
    public FSMState CurrentState;    
    public enum EmotionalState { Default, Interested, Panic }
    public EmotionalState CurrentEmotionalState = EmotionalState.Default;
    #region Public

    //TODO: Maybe this is obsolete? Test how causing panic from external source works in practice...
    /*
    public void SetEmotionalState(EmotionalState emotionalState, float? returnToDefaultAfterSeconds)
    {
        //Set new current state
        CurrentEmotionalState = emotionalState;

        //Return to default state after timer has run
        if (returnToDefaultAfterSeconds.HasValue)
            Observable.Timer(TimeSpan.FromSeconds(returnToDefaultAfterSeconds.Value)).Take(1).Subscribe(x => { CurrentEmotionalState = EmotionalState.Default; Debug.Log("*** Timer ended, changed emotion!"); }).AddTo(this);
    }
    */
    #endregion

    #region Unity
    protected virtual void Awake()
    {
        CurrentState = initialState;
    }

    protected override void Update()
    {
        base.Update();
        CurrentState.ExecuteState(this);
    }
    #endregion
}
