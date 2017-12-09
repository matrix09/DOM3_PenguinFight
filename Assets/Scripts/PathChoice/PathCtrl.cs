using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCtrl : MonoBehaviour {


    public BaseAction[] actions;

    public bool m_bIsTriggerOnce;

    void OnTriggerEnter(Collider other)
    {

        if (m_bIsTriggerOnce)
            return;

        if (!m_bIsTriggerOnce)
            m_bIsTriggerOnce = true;

        //只处理玩家
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].TrigAction();
            }
        }


    }
}
