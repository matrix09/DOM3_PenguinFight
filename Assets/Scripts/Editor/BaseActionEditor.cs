using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AttTypeDefine;
[CustomEditor(typeof(BaseAction))]
public class BaseActionEditor : Editor {

    BaseAction bsaction;

    public string[] options = new string[] { "自动触发", "条件触发" };

    void OnEnable()
    {
        bsaction = target as BaseAction;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        #region 选择触发条件
        Rect rect;
        EditorGUILayout.Space();
        rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
        EditorGUILayout.LabelField("触发方式");
        int m_condition = EditorGUILayout.Popup((int)bsaction.m_condition, options);
        if (m_condition != (int)bsaction.m_condition)
        {
            bsaction.m_condition = (eDelayTimeType)m_condition;
            EditorUtility.SetDirty(bsaction.gameObject);
        }
        EditorGUILayout.EndHorizontal();
        #endregion

        //如果是自动触发
        if (bsaction.m_condition == eDelayTimeType.DelayTime_Audo)
        {
            #region 自动触发延迟时间
            rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
            float m_fDelayTime = EditorGUILayout.FloatField("自动触发延迟时间", bsaction.m_fDelayTime);
            if (bsaction.m_fDelayTime != m_fDelayTime)
            {
                bsaction.m_fDelayTime = m_fDelayTime;
                EditorUtility.SetDirty(bsaction.gameObject);
            }
            EditorGUILayout.EndHorizontal();
            #endregion
        }
        //如果是条件触发
        else if (bsaction.m_condition == eDelayTimeType.DelayTime_Condition)
        {
            #region 自动触发延迟时间
            rect = EditorGUILayout.BeginHorizontal(GUILayout.Height(30));
            float m_fDelayTime = EditorGUILayout.FloatField("条件触发延迟时间", bsaction.m_fDelayTime);
            if (bsaction.m_fDelayTime != m_fDelayTime)
            {
                bsaction.m_fDelayTime = m_fDelayTime;
                EditorUtility.SetDirty(bsaction.gameObject);
            }
            EditorGUILayout.EndHorizontal();
            #endregion
        }



    }



	
}
