using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// Base class for characters using FSM.
/// </summary>
public class FSMCharacter : NavMeshAgentCharacter
{
    public enum EmotionalState { Default, Interested, Panic }

    [Header("FSM Character Settings")]
    [SerializeField, Tooltip("State from which the AI starts executing next states depending on decisions.")] 
    private FSMState initialState;
    [Tooltip("Transitions that are allowed from any state.")]
    public List<FSMTransition> FromAnyStateTransitions = new List<FSMTransition>();

    [ReadOnly, Tooltip("Current state for debugging.")] 
    public FSMState CurrentState;        
    public EmotionalState CurrentEmotionalState = EmotionalState.Default;
    
    //Position that causes current emotional state
    public Vector3 EmotionalStateCausePosition { get; private set; }

    #region Public
    public void SetEmotionalState(EmotionalState emotionalState, Vector3 causePosition, float? returnToDefaultAfterSeconds)
    {
        //Set new current state
        CurrentEmotionalState = emotionalState;
        //Set position that causes current emotional state
        EmotionalStateCausePosition = causePosition;
        //TODO: for now just use RunSpeed when in panic and otherwise use WalkSpeed
        Agent.speed = emotionalState == EmotionalState.Panic ? RunSpeed : WalkSpeed;

        //Return to default state after timer has run
        if (returnToDefaultAfterSeconds.HasValue)
            Observable.Timer(TimeSpan.FromSeconds(returnToDefaultAfterSeconds.Value)).Take(1).Subscribe(x => 
            { 
                CurrentEmotionalState = EmotionalState.Default;
                //TODO: for now reset to WalkSpeed
                Agent.speed = WalkSpeed;
            }).AddTo(this);
    }
    
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
