using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using  Assets.Scripts.Stellar;
public class CameraCtrl : MonoBehaviour
{

    BaseActor m_cMajor;

    public Vector3 offSet;

    public Vector3 dir;

    public float offSpeed;

    public float dirSpeed;

    eCameraType m_eCamType = eCameraType.Cam_Follow;

    Stellar m_cStellar;
    float m_fT = 0f;
    public void SetCamType (eCameraType type, Stellar curveInfo) {
        m_eCamType = type;
        m_cStellar = curveInfo;
        m_fT = 0f;
    }

    public void OnStart(BaseActor ba)
    {
        m_cMajor = ba;
    }

    void Update()
    {

        if (null == m_cMajor)
            return;

        if (m_eCamType == eCameraType.Cam_Follow)
        {
            Vector3 pos = m_cMajor.ATrans.position + offSet;

            transform.position = Vector3.Lerp(transform.position, pos, offSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(dir), dirSpeed * Time.deltaTime);

        }
        else if (m_eCamType == eCameraType.Cam_Anim)
        {
            if (null != m_cStellar)
            {
                if (m_fT >= 1)
                {
                    m_fT = 1f;
                }

                //读取曲线位置.
                transform.position = Vector3.Lerp(transform.position, m_cStellar.Interp(m_fT), 5f * Time.deltaTime);
                //读取曲线方向.
                transform.forward = Vector3.Lerp(transform.forward, m_cStellar.GetDir(m_fT), 5f * Time.deltaTime); ;
                //增加进度.
                m_fT += m_cStellar.GetDeltaT(m_fT) * Time.deltaTime;


            }
        }
      

    }
}


