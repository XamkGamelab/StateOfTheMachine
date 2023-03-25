using UnityEngine;
using System.Linq;

    [CreateAssetMenu(menuName = "FSM/Decisions/In Line Of Sight")]
    public class FSMDecisionInterestingInSight : FSMDecision
    {
        public override bool Decide(FSMCharacter stateMachine)
        {
            AISensor enemySightSensor = stateMachine.GetComponent<AISensor>();
            return enemySightSensor.Objects.FirstOrDefault() != null ? true : false;        
        }
    }
