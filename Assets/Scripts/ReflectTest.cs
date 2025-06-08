using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectTest : MonoBehaviour
{
    public Transform A;
    public Transform C;
    private Vector2 b;

    private Vector2 hit_point = Vector2.zero;
    private Vector2 hit_norm = Vector2.up.normalized;



    private void OnDrawGizmos()
    {
        Vector2 c = C.position;
        Vector2 cNorm = c.normalized;
        
        Vector2 a = A.position;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(a, 0.05f);
        Gizmos.DrawLine(default, a);

        Vector2 aNorm = a / a.magnitude;

        float scalar_projection_y = Vector2.Dot(cNorm, a);
        Vector2 vec_projection_y = cNorm * scalar_projection_y;

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(vec_projection_y, 0.07f);
        //float scalar_projection =

        Vector2 vec_projection_x = a - vec_projection_y;
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(vec_projection_x, 0.07f);

        Vector2 reflected_projection_x = -vec_projection_x;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(reflected_projection_x, 0.07f);

        b = reflected_projection_x + vec_projection_y;
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(b, 0.05f);
        Gizmos.DrawLine(default, b);

    }



}
