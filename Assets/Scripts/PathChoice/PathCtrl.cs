using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCtrl : MonoBehaviour {


    public BaseAction[] actions;

    public bool m_bIsTriggerOnce = true;

    bool m_bFirst = false;
    void OnTriggerEnter(Collider other)
    {

        if (m_bIsTriggerOnce)
        {
            if (m_bFirst == true)
                return;
            m_bFirst = false;
        }
      
        //只处理玩家
        if (other.gameObject.tag == "Player")
        {

            //设置主角
            SetOwner(GlobalHelper.GetBaseActorFromParent(other.gameObject));


            for (int i = 0; i < actions.Length; i++)
            {
                if(actions[i].m_condition == AttTypeDefine.eDelayTimeType.DelayTime_Condition)
                     actions[i].OnStart();
            }

         
        }


    }

    void SetOwner(BaseActor owner)
    {

        BaseAction[] actions = gameObject.GetComponents<BaseAction>();

        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].DataStore.Owner = owner;
        }

    }

}
