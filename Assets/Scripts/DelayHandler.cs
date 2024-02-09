using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DelayHandler
{
    public static IEnumerator DelayAction(float s, System.Action callback)
    {
        yield return new WaitForSeconds(s);
        callback.Invoke();
    }
}
