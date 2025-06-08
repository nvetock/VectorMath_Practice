using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{

    public Transform A;
    public Transform B;

    private Vector2 C = Vector2.zero;

    private void Start()
    {
        
        C = A.position - B.position;
    }

    

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, 1);
        Vector2 a = A.position;
        Vector2 b = B.position;


        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, a);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(default, b);




        // normalizing

        float aLen = Mathf.Sqrt(a.x * a.x + a.y * a.y);
        // float aLen = a.magnitude;


        Vector2 aNorm = a/aLen;
        // Vector2aNorm = a.normalized;

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(aNorm, 0.1f);
        //Gizmos.DrawSphere(default, aLen);


        // Dot product of Scalar Projection
        //Vector2 c = aNorm * b;
        float scalar_projection = Vector2.Dot(aNorm, b);

        Vector2 vector_projection = aNorm * scalar_projection;

        Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(default, vector_projection);
        Gizmos.DrawSphere(vector_projection, 0.05f);



        Vector2 reflect_dir = a/aLen;
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(reflect_dir, 0.05f);
    }


}
