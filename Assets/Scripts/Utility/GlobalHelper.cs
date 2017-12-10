using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHelper  {


    public static float GetCurTime (bool ignoreTimeScale = false) {

        if (ignoreTimeScale)
            return Time.realtimeSinceStartup;
        else
            return Time.time;
    }

    public static BaseActor GetBaseActorFromParent(GameObject obj)
    {

        BaseActor ba = obj.GetComponent<BaseActor>();
        if (ba == null)
        {
            if (null != obj.transform.parent)
            {
                ba = GetBaseActorFromParent(obj.transform.parent.gameObject);
                if (null != ba)
                    return ba;
            }
        }

        return ba;
    }


	
}
