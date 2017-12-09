using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Stellar;
public class StartPosition : MonoBehaviour {

    BaseActor Owner;

    public void OnStart(BaseActor ba)
    {
        //初始化主角信息
        Owner = ba;

        //初始化出生的曲线点
        Owner.CurveInfos = gameObject.GetComponent<Stellar>();
    }

	
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);

    }

}
