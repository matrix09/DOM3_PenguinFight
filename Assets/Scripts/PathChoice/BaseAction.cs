using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;

public class BaseAction : MonoBehaviour {

    public bool m_bIsIgnoreTimeScale;

    //延迟触发时间
    [HideInInspector]
    public float m_fDelayTime;

    [HideInInspector]
    public eDelayTimeType m_condition;

    float m_fStartTime;
    bool m_bStart;

    PC_DataStore datastore;
    public PC_DataStore DataStore
    {
        get {
            if (!datastore)
            {
                datastore = gameObject.GetComponent<PC_DataStore>();
            }
            return datastore;
        }
    }

    void Awake()
    {
        if (m_condition == eDelayTimeType.DelayTime_Audo)
        {
            m_fStartTime = GlobalHelper.GetCurTime(m_bIsIgnoreTimeScale);
            m_bStart = true;
        }
    }

    public void OnStart()
    {
        if (m_condition == eDelayTimeType.DelayTime_Condition)
        {
            m_bStart = true;
            m_fStartTime = GlobalHelper.GetCurTime(m_bIsIgnoreTimeScale);
        }
    }

    void Update()
    {
        CalTime();
    }

    void CalTime()
    {

        if (!m_bStart)
            return;

        if (GlobalHelper.GetCurTime(m_bIsIgnoreTimeScale) - m_fStartTime > m_fDelayTime)
        {
            TrigAction();
            m_bStart = false;
        }
    }

    public virtual void TrigAction() { }

}
