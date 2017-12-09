using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttTypeDefine  {


    //延迟类型
    public enum eDelayType
    {
        Delay_Percent,
        Delay_Time,
    };

    //时间延迟类型
    public enum eDelayTimeType
    {
        DelayTime_Audo,
        DelayTime_Condition,
    };

    //角色行为控制类型
    public enum eCharacterBehaType
    {
        Character_SelfControl,
        Character_SystemControl,
    };

    //相机类型
    public enum eCameraType
    {
        Cam_Anim,
        Cam_Follow,
    }




	
}
