using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;

    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        Vector3 getPos = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        transform.position = getPos;
    }
}
