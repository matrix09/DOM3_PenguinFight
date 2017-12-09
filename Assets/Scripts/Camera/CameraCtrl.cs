using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    BaseActor m_cMajor;

    public Vector3 offSet;

    public Vector3 dir;

    public float offSpeed;

    public float dirSpeed;


    public void OnStart(BaseActor ba)
    {
        m_cMajor = ba;
    }

    void Update()
    {

        if (null == m_cMajor)
            return;

        Vector3 pos = m_cMajor.ATrans.position + offSet;

        transform.position = Vector3.Lerp(transform.position, pos, offSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(dir), dirSpeed * Time.deltaTime);

    }
}


