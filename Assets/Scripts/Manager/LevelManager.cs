using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    //加载场景资源
    public void LoadSceneRes(int Sceneiid)
    {

        if (Sceneiid == -1)
        {
            //加载制定路径的资源, 加载制定路径的模型
            UnityEngine.Object[] objs = Resources.LoadAll("Prefabs/Maps/Map_1001");
            StartPosition sp = null;
            for (int i = 0; i < objs.Length; i++)
            {
                GameObject obj = Instantiate(objs[i]) as GameObject;

                obj.name = objs[i].name;

                if (obj.name.CompareTo("StartPosition") == 0)
                {
                    sp = obj.GetComponent<StartPosition>();
                }
            }

            //实例化主角
            BaseActor ba = BaseActor.CreatePlayer("Prefabs/Character/Penguins/Prefab/PenguinA", "Local Major", sp.transform.position, sp.transform.rotation);

            //启动相机
            CameraCtrl cc = Camera.main.GetComponent<CameraCtrl>();
            cc.OnStart(ba);

            //启动位置
            sp.OnStart(ba);

        }

    }

}
