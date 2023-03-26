using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Base class for all characters using NavMeshAgent.
/// </summary>
[RequireComponent(typeof(NavMeshAgent), typeof(Collider), typeof(Animator))]
public abstract class NavMeshAgentCharacter : MonoBehaviour
{
    
    public NavMeshAgent Agent => GetComponent<NavMeshAgent>();
    public Animator Anim => GetComponent<Animator>();
    
    [Header("Agent Basic Settings")]
    public float WalkSpeed = 3f;
    public float RunSpeed = 6f;

    public List<Transform> PatrolPointTransforms;
    public Transform CurrentPatrolPoint { get; private set; }

    private int currentPPIndex = 0;
    #region Public

    public void SetNextPatrolPointDestination()
    {
        if (PatrolPointTransforms.Count > 0)
        {
            if (currentPPIndex < PatrolPointTransforms.Count)
            {
                CurrentPatrolPoint = PatrolPointTransforms[currentPPIndex];
                currentPPIndex++;
                SetDirectAgentDestination(CurrentPatrolPoint.position);
            }
            else
                currentPPIndex = 0;
        }
        else
            Debug.LogError("You have to set PatrolPoints for this action to work!");
    }

    public void SetDirectAgentDestination(Vector3 destinationPosition)
    {
        Agent.SetDestination(destinationPosition);
    }
    #endregion

    #region Protected
    protected virtual void SetAnimationParameters()
    {
        Anim.SetFloat(GameHelper.AnimationAttributeNameAgentSpeed, Agent.velocity.magnitude);
    }
    #endregion

    #region Unity
    protected virtual void Update()
    {
        SetAnimationParameters();
    }
    #endregion
}
