using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Stellar;
public class PlayerManager : MonoBehaviour
{   
    
    #region 变量
    Stellar m_cStellar;  //获取曲线信息
    float m_fT = 0f;
    const float headPer = 0.01f;
    Vector3 pos;
    Vector3 headPos;
    
    
    float he = 0f;
    BaseActor owner;
    public BaseActor Owner
    {
        get
        {
            return owner;
        }
        set
        {
            if (value != owner)
                owner = value;
        }
    }
    #endregion

    #region 角色移动
    void CharacterMove()
    {

        if (!Owner.CurveInfos)
            return;

        if (null == m_cStellar)
            m_cStellar = Owner.CurveInfos;

        he = Input.GetAxis("Horizontal");
        if (he == 0f)
        {
            Owner.AM.SetFloat("Speed", 0f);
            return;
        }

        if (m_fT >= 1f && he >= 0f)
        {
            m_cStellar.LinkPoints(out m_fT);
            m_fT = 0f;
        }

        if (m_fT < 0f)
            m_fT = 0f;

        if (m_fT >= headPer && m_fT <= 1f)
        {
            if (he > 0f)
            {
                headPos = m_cStellar.Interp(m_fT + headPer);
            }
            else
            {
                headPos = m_cStellar.Interp(m_fT - headPer);
            }

            Owner.ATrans.LookAt2D(headPos);

        }

        pos = m_cStellar.Interp(m_fT);
        Owner.ATrans.position = Vector3.Lerp(Owner.ATrans.position, new Vector3(pos.x, Owner.ATrans.position.y, pos.z), 5 * Time.deltaTime);

        m_fT += m_cStellar.GetDeltaT(m_fT) * Time.deltaTime * (he > 0f ? 1 : -1);

        Owner.AM.SetFloat("Speed", 1f);
        
    }
    #endregion

    #region 系统接口

    void Update()
    {
        CharacterMove();    //角色运动
    }
    #endregion

}   
