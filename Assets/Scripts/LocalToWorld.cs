using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalToWorld : MonoBehaviour
{

    public Vector3 child_pos = Vector3.zero;
    public Quaternion child_rot = Quaternion.identity;
    public Transform child;


    Vector3 LocToWorld(Vector3 local_position)
    {
        return transform.position + local_position;
    }

    private void Update()
    {
        Debug.Log(LocToWorld(child.position));
    }


    private void OnDrawGizmos()
    {
        //Transform child = GetComponentInChildren<Transform>();

        child.GetLocalPositionAndRotation(out child_pos, out child_rot);


        Gizmos.color = Color.red;
        Gizmos.DrawSphere(child.position, 0.05f);
    }

}
