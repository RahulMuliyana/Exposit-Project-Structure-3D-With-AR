using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CallFunctions : MonoBehaviour
{

    public UnityEvent CallThisFunctionWhenObjectOn;
    public UnityEvent CallEventByAnimation;
    public float DelayTime = 2.0f;
    public UnityEvent CallDelayEvent;
 

    public void Start()
    {
        StartCoroutine(DelayEvent());
        CallThisFunctionWhenObjectOn.Invoke();
    }
    public void CallEvent()
    {
        CallEventByAnimation.Invoke();
    }
    IEnumerator DelayEvent()
    {
        yield return new WaitForSeconds(DelayTime);
        CallDelayEvent.Invoke();
    }

}
