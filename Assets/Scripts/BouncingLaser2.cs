using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BouncingLaser2 : MonoBehaviour
{
    public Transform[] wallNodes = new Transform[8];



    private void OnDrawGizmos()
    {
        float amt_to_rotate = 45.0f;
        float wall_length = 3.0f;
        
        Vector2[] wns = new Vector2[8];
        for (int i = 0; i < wallNodes.Length; i++)
        {
            wns[i] = wallNodes[i].position;

            wallNodes[i].rotation = Quaternion.Euler(0, 0, amt_to_rotate * i);

            //wallNodes[i].position = transform.up * wall_length;

            Gizmos.color = Color.white;
            Gizmos.DrawLine(wns[i] - (Vector2.left * wall_length), wns[i] - (Vector2.right * wall_length));
        }





    }
}


