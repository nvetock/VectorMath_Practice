using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncingLaser : MonoBehaviour
{

    public int total_bounces = 5;
    public int curr_bounce = 0;
    public float laser_length = 20.0f;
    float laser_drawLine_width = 0.3f;

    public LineRenderer line;
    public Vector3 local_pos_up = Vector2.up;

    private Vector3 pos = Vector3.zero;


    private Vector3 laser_pos = Vector3.zero;
    private Vector3 laser_dir = Vector3.zero;



    private void Awake()
    {
        line = transform.GetComponent<LineRenderer>();

    }

    private void Start()
    {
        line.positionCount = 6;
        //line.SetVertexCount(total_bounces);


        //local_pos_up = Vector3.up * Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        //Quaternion rot_z = transform.rotation.z;

        /*
        if (Physics.Raycast(pos, transform.up, out hit))
        {
            Vector3 incoming_transform = transform.up.normalized;
            Vector3 collider_transform = hit.point;

            float scalar_projection = Vector3.Dot(incoming_transform, hit.point);

            Vector3 vector_projection = scalar_projection * incoming_transform;

            RaycastHit nextHit;
            Physics.Raycast(hit.point, vector_projection, out nextHit);


            //AddLine(pos, hit.point);
            //AddLine(hit.point, nextHit.point);


            line.SetPosition(0, pos);
            line.SetPosition(1, hit.point);

            line.SetPosition(2, nextHit.point);

            RaycastHit nextnextHit;
            Physics.Raycast(hit.point, vector_projection, out nextnextHit);
            line.SetPosition(3, nextnextHit.point);

        }
        */

        /*
        laser_pos = transform.position;
        laser_dir = transform.up;


        RaycastHit hit;

        for (int i = 0; i < line.positionCount; i++)
        {
            if (Physics.Raycast(laser_pos, -(laser_dir.normalized), out hit))
            {
                addLine(laser_pos);
                process_next_hit(hit);
            }
        }
        */

        laser_pos = transform.position;
        laser_dir = transform.up.normalized;

        /*
        RaycastHit hit;
        Physics.Raycast(laser_pos, laser_dir, out hit);
        Debug.Log("normal: " + hit.normal);
        Debug.Log("point: " + hit.point);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point);

        //hit.normal

        //addLine(hit.point);
        //addLine(hit.point);

        //Vector3 bounce_dir = laser_dir * hit.normal;
        */
        addLine(laser_pos);
        for (int i = 1; i < line.positionCount; i++)
        {
            LaserBeam();
        }
    }

    void LaserBeam()
    {
        RaycastHit hit;
        Physics.Raycast(laser_pos, laser_dir, out hit);
        Debug.Log("Collider " + hit.collider.name + " hit at: " + hit.point + "| normal: " + hit.normal);

        float y_scalar_projection = Vector3.Dot(hit.normal, laser_pos);
        Vector3 y_projection_pos = hit.normal * y_scalar_projection;

        Vector3 x_projection_pos = laser_pos - y_projection_pos;

        Vector3 x_reflect_pos = -x_projection_pos;

        laser_pos = hit.point;
        laser_dir = (x_reflect_pos - hit.point).normalized;
        Debug.Log("Sending ray towards: " + laser_dir);
        addLine(laser_pos);
    }

    void LaserBeam2()
    {
        RaycastHit hit;
        if (Physics.Raycast(laser_pos, laser_dir, out hit))
        {
            Debug.Log("Collider " + hit.collider.name + " hit at: " + hit.point + "| normal: " + hit.normal);

            laser_pos = hit.point;

            Vector3 norm = hit.normal.normalized;
            Vector3 dir = laser_dir.normalized;

            //Reflection
            Vector3 reflectedDir = dir - 2f * Vector3.Dot(dir, norm) * norm;

            // Nudge to avoid a re-hit
            //laser_pos += laser_dir * 0.01f;
            addLine(laser_pos);

        }
    }


    void AddLine(Vector3 a, Vector3 b)
    {
        line.startWidth = laser_drawLine_width;
        line.endWidth = laser_drawLine_width;
        line.SetPosition(0, a);
        line.SetPosition(1, b);
    }

    void addLine(Vector3 p)
    {
        line.SetPosition(curr_bounce, p);
        curr_bounce++;
        Debug.Log(curr_bounce);
    }

    void process_next_hit(RaycastHit h)
    {
        float scalar_projection = Vector3.Dot(laser_dir, h.point);
        laser_dir = (scalar_projection * laser_dir); // maybe normalize?

        addLine(laser_pos);

        laser_pos = h.point;
    }


}
