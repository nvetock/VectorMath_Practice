using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{

    public float radius = 5.0f;
    public Transform other;

    private void OnDrawGizmos()
    {

        Vector2 other_pos = other.position;
        float other_length = Mathf.Sqrt(other_pos.x * other_pos.x + other_pos.y * other_pos.y);
        Vector2 other_norm = other_pos / other_length;


        Vector2 radiusVector = other_norm * radius;
        Vector2 offset = transform.position;


        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, other_pos);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(radiusVector + offset, 0.1f);


        if (Mathf.Abs(other.position.x) < Mathf.Abs((radiusVector + offset).x)
            || Mathf.Abs(other.position.y) < Mathf.Abs((radiusVector + offset).y))
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawSphere(transform.position, 0.2f);

        //if (other.position < radiusVector)


    }

}
