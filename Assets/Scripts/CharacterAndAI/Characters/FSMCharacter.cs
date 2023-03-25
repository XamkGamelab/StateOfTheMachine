using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FSMCharacter : NavMeshAgentCharacter
{
    [SerializeField, Tooltip("State from which the AI starts executing next states depending on decisions.")] private FSMBaseState _initialState;    
    [ReadOnly, Tooltip("Current state for debugging.")] public FSMBaseState CurrentState;

    public enum EmotionalState { Default, Interested, Afraid }
    public EmotionalState CurrentEmotionalState = EmotionalState.Default;
    #region Public
    public void SetEmotionalState(EmotionalState emotionalState, float? returnToDefaultAfterSeconds)
    {
        //Set new current state
        CurrentEmotionalState = emotionalState;

        //Return to default state after timer has run
        if (returnToDefaultAfterSeconds.HasValue)
            Observable.Timer(TimeSpan.FromSeconds(returnToDefaultAfterSeconds.Value)).Take(1).Subscribe(x => CurrentEmotionalState = EmotionalState.Default).AddTo(this);
    }
    #endregion

    #region Unity
    protected virtual void Awake()
    {
        CurrentState = _initialState;
    }

    protected override void Update()
    {
        base.Update();
        CurrentState.Execute(this);
    }
    #endregion
}
