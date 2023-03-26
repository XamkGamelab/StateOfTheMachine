using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sight sensor that scans "pie slice" area of given angle and distance.
/// Checks collisions from scanned area and keeps track of them in Objects list.
/// </summary>
[ExecuteInEditMode]
public class AISensor : MonoBehaviour
{
    public float SensorAngle = 30f;
    public float SensorDistance = 5f;
    public float SensorHeight = 2f;
    public Color MeshColor = Color.red;
    public int ScanFrequency = 30;
    
    public LayerMask ScanLayers;
    public LayerMask OcclusionLayers;

    public List<GameObject> Objects = new List<GameObject>();
    private Collider[] colliders = new Collider[50];
    private int count;
    
    private float scanInterval;
    private float scanTimer;
    
    private Mesh aiSensorWedgeMesh;

    public bool IsInSight(GameObject go)
    {
        Vector3 origin = transform.position;
        Vector3 dest = go.transform.position;
        Vector3 direction = dest - origin;
        if (direction.y < 0 || direction.y > SensorHeight)        
            return false;
        
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if (deltaAngle > SensorAngle)
            return false;

        origin.y += SensorHeight * .5f;
        dest.y = origin.y;
        if (Physics.Linecast(origin, dest, OcclusionLayers))
            return false;
        
        return true;
    }

    private void Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, SensorDistance, colliders, ScanLayers, QueryTriggerInteraction.Collide);
        
        Objects.Clear();
        for (int i = 0; i < count; i++)
        {
            GameObject go = colliders[i].gameObject;
            if (IsInSight(go))
            {
                Objects.Add(go);
            }
        }
    }
    private void Awake()
    {
        scanInterval = 1.0f / ScanFrequency;
    }

    private void Update()
    {
        
        scanTimer -= Time.deltaTime;
        if (scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }        
    }

    private void OnValidate()
    {
        aiSensorWedgeMesh = WedgeMesh.GenerateWedgeMesh(SensorAngle, SensorDistance, SensorHeight);
        scanInterval = 1.0f / ScanFrequency;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = MeshColor;

        if (aiSensorWedgeMesh != null)
        {
            Gizmos.DrawMesh(
                WedgeMesh.UpdateWedgeMesh(aiSensorWedgeMesh, SensorAngle, SensorDistance, SensorHeight),
                transform.localPosition, 
                transform.localRotation);
        }

        Gizmos.DrawWireSphere(transform.position, SensorDistance);
        for (int i = 0; i < count; i++)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }

        Gizmos.color = Color.green;
        foreach (GameObject go in Objects)
        {
            Gizmos.DrawSphere(go.transform.position, 1f);
        }
    }
}
