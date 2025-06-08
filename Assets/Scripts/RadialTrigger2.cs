using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class RadialTrigger2 : MonoBehaviour
{
    [SerializeField]
    Transform objTf;

    [Range(0f, 4f)]
    public float radius = 1f;



#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 objPos = objTf.position;
        Vector2 origin = transform.position;

        Vector2 displacement_vector = objPos - origin;
        
        
        // Distance can be found a few different ways
        // float dist = Vector2.Distance(objPos, origin);
        //float dist = Mathf.Sqrt(displacement_vector.x * displacement_vector.x + displacement_vector.y * displacement_vector.y);
        float distSq = displacement_vector.x * displacement_vector.x + displacement_vector.y * displacement_vector.y;
        //float distSq = displacement_vector.sqrMagnitude;

        float radiusSq = radius * radius;

        // using squares instead of the square root distance is much more performant
        bool isInside = distSq < radiusSq;

        Handles.color = isInside ? Color.green : Color.red;
        Handles.DrawWireDisc(origin, Vector3.forward, radius);
        
    }
#endif
}
