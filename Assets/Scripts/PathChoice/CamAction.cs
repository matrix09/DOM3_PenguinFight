using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Stellar;

public class CamAction : BaseAction {

    //相机行为类型
    public eCameraType m_eCamType = eCameraType.Cam_Follow;

    //曲线信息
    public Stellar m_cStellar;

    public override void TrigAction()
    {
        //如果是动画类型
        if (m_eCamType == eCameraType.Cam_Anim)
        {
            //1 ： 第零个点计算方式 ： 当前相机的位置 * 2 - 当前主角的位置
            //2 ： 第一个点的计算方式 ： 当前相机的位置
            //3 ： 第二个点的位置不变
            //4 ： 第三个点的位置不变
            
            BaseActor major = DataStore.Owner;//主角
            Vector3 campos = Camera.main.transform.position;//相机位置

            Vector3 majorpos = new Vector3(major.ATrans.position.x, campos.y, major.ATrans.position.z);

            Vector3 p0 = campos * 2 - majorpos;
            p0 = m_cStellar.transform.InverseTransformPoint(p0);

            Vector3 p1 = campos;
            p1 = m_cStellar.transform.InverseTransformPoint(p1);

            m_cStellar.Points[0] = p0;
            m_cStellar.Points[1] = p1;

            m_cStellar.Points[2] = new Vector3(m_cStellar.Points[2].x, p1.y, m_cStellar.Points[2].z);
            m_cStellar.Points[3] = new Vector3(m_cStellar.Points[3].x, p1.y, p1.z);


            //把曲线信息和相机状态告诉相机
            major.CamCtrl.SetCamType(m_eCamType, m_cStellar);

        }
    }
}
