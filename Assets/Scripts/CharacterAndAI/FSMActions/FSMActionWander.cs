using UnityEngine;

/// <summary>
/// Wander ramdomly on area constrained by MinWanderAreaXZ and MaxWanderAreaXZ values.
/// </summary>
[CreateAssetMenu(menuName = "FSM/Actions/Wander Around")]
public class FSMActionWander : FSMAction
{
    public Vector2 MinWanderAreaXZ = new Vector2(-10f, -10f);
    public Vector2 MaxWanderAreaXZ = new Vector2(10f, 10f);

    public float CloseEnoughDistance = 0.5f;
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        
        if (!stateMachine.Agent.hasPath || stateMachine.Agent.remainingDistance < CloseEnoughDistance)
        {
            stateMachine.SetDirectAgentDestination(new Vector3(Random.Range(MinWanderAreaXZ.x, MaxWanderAreaXZ.x), 0, Random.Range(MinWanderAreaXZ.y, MaxWanderAreaXZ.y)));
        }
    }
}
