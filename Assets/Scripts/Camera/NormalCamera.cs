using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCamera : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 offsetPos = new Vector3(0f, 3f, -8f);
    [SerializeField]
    Space offsetPosSpace = Space.Self;
    [SerializeField]
    bool lookAt = true;

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        UpdatePos();
        UpdateRot();
    }

    void UpdatePos()
    {
        if(offsetPosSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPos);
        }
        else
        {
            transform.position += target.position + offsetPos;
        }
    }
    void UpdateRot()
    {
        if(lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
