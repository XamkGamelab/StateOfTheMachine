using System;
using UnityEngine;
using UniRx;

public class InterestingObject : MonoBehaviour
{
    public float IsInterestingForSeconds = 4f;
    public float InterestReturnCooldown = 10f;
    private bool isInteresting = true;

    private bool interestOnCoolDown = false;
    public bool IsStillInteresting()
    { 
        if (!interestOnCoolDown)
        {
            isInteresting = true;
            interestOnCoolDown = true;
            //Object can be interesting again after InterestReturnCooldown...
            Observable.Timer(TimeSpan.FromSeconds(InterestReturnCooldown)).Take(1).Subscribe(x => interestOnCoolDown = false).AddTo(this);
            //But is no longer interesting after IsInterestingForSeconds
            Observable.Timer(TimeSpan.FromSeconds(IsInterestingForSeconds)).Take(1).Subscribe(x => isInteresting = false).AddTo(this);
        }

        return isInteresting;
    }
}
