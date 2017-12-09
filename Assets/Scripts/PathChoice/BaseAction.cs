using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
public class BaseAction : MonoBehaviour {

    //延迟触发时间
    public float m_fDelayTime;

    [HideInInspector]
    public eDelayTimeType m_condition;


    public virtual void TrigAction() { }


}
