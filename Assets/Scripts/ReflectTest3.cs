using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectTest3 : MonoBehaviour
{
    public Transform wall1_A;
    public Transform wall1_B;
    
    public Transform wall2_A;
    public Transform wall2_B;

    public Transform laser_base;
    public Transform laser_pointer;
    



    private void OnDrawGizmos()
    {
        CreateWalls();

        Vector2 laser_dir = new(1, -1);
        float laser_length = 5.0f;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(laser_base.position, laser_dir * laser_length);

    }


    void CreateWalls()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(wall1_A.position, wall1_B.position);
        Gizmos.DrawLine(wall2_A.position, wall2_B.position);
    }

}
