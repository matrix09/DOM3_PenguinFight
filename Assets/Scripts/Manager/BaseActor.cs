using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttTypeDefine;
using Assets.Scripts.Stellar;
public class BaseActor : MonoBehaviour
{
    #region 角色实例对象
    private GameObject actor;
    public Transform ATrans
    {
        get
        {
            return actor.transform;
        }
    }
    #endregion

    #region 角色行为控制器
    PlayerManager playermgr;
    public PlayerManager PlayerMgr
    {
        get
        {
            if(null == playermgr)
                playermgr = gameObject.AddComponent<PlayerManager>();
            return playermgr;
        }
    }

    #endregion

    #region 创建角色
    public static BaseActor CreatePlayer(string path, string name, Vector3 pos, Quaternion rot)
    {

        #region create parent
        GameObject parentobj = new GameObject(name);
        parentobj.transform.position = Vector3.zero;
        parentobj.transform.rotation = Quaternion.identity;
        parentobj.transform.localScale = Vector3.one;
        #endregion

        BaseActor ba = CreateActor(parentobj, path, pos, rot);

        if (null != ba.PlayerMgr)
        {
            ba.PlayerMgr.Owner = ba;
        }

        return ba;

    }

    static BaseActor CreateActor(GameObject parentobj, string path, Vector3 pos, Quaternion rot)
    {

        UnityEngine.Object _obj = Resources.Load(path);

        GameObject obj = Instantiate(_obj) as GameObject;

        BaseActor ba = parentobj.AddComponent<BaseActor>();

        obj.transform.parent = parentobj.transform;
        obj.transform.localPosition = pos;
        obj.transform.localRotation = rot;
        obj.transform.localScale = Vector3.one;

        //初始化角色
        ba.actor = obj;

        return ba;

    }
    #endregion

    #region 保存角色行为模式 : r/w.
    private eCharacterBehaType charactype;
    public eCharacterBehaType CharacterType
    {
        get
        {
            return charactype;
        }
        set
        {
            if (value != charactype)
                charactype = value;
        }
    }
    #endregion

    #region 动画控制器
    private Animator am;
    public Animator AM
    {
        get
        {
            if(null == am)
                am = actor.GetComponent<Animator>();
            return am;
        }
    }
    #endregion

    #region 曲线信息
    private Stellar stellar;
    public Stellar CurveInfos
    {
        get
        {
            return stellar;
        }
        set
        {
            if (value != stellar)
                stellar = value;
        }
    }

    #endregion


}
