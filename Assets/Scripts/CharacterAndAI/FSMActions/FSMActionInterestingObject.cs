using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[CreateAssetMenu(menuName = "FSM/Actions/Sight Interesting Object")]
public class FSMActionInterestingObject : FSMAction
{
    public override void Execute(FSMCharacter stateMachine)
    {
        base.Execute(stateMachine);
        Debug.Log("Execute sight interesting object");
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        AISensor enemySightSensor = stateMachine.GetComponent<AISensor>();
        GameObject firstObject = enemySightSensor.Objects.FirstOrDefault();
        navMeshAgent.SetDestination(firstObject.transform.position);
    }
}
