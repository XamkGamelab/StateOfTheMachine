using UnityEngine;

/// <summary>
/// Render lightning bolt effect with LineRenderer.
/// </summary>
public class LightningBolt : MonoBehaviour
{
    [ColorUsage(true, true)] //HDR color for the lightning
    public Color LightningColor;
    public float LightningHeight = 20f;
    public float LightningWidth = 0.06f;
    public int LightningSegments = 10;
    public float MaxRandomnessXZ = 1f;
    public float LightMaxIntensity = 3f;
    public int UpdateFrequency = 30;
    public float DrawGizmoRadius = 10f;

    private float segmentLength => LightningHeight / LightningSegments;
    private LineRenderer lineRenderer;
    private Light pointLight => GetComponentInChildren<Light>();
    private float updateInterval => 1.0f / UpdateFrequency;
    private float updateTimer;
    
    #region Unity
    private void Awake()
    {
        SetupLightningLineRenderer();
        Destroy(gameObject, .5f);
    }

    private void Update()
    {
        updateTimer -= Time.deltaTime;
        if (updateTimer < 0)
        {
            updateTimer += updateInterval;
            UpdateLightningLineRenderer();
            pointLight.intensity = Random.Range(0, LightMaxIntensity);
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawWireSphere(transform.position, DrawGizmoRadius);
    }
    #endregion

    private void SetupLightningLineRenderer()
    {
        //Add LineRenderer to go and set up basic stuff
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = LightningWidth;
        lineRenderer.startColor = lineRenderer.endColor = LightningColor;
    }

    private void UpdateLightningLineRenderer()
    {
        //Reset to ground hit position
        lineRenderer.SetPosition(0, transform.localPosition);
        lineRenderer.positionCount = 1;

        //Draw and animate segments
        for (int i = 1; i < LightningSegments; i++)
        {
            //Add randomness on x and z axes
            float r = Random.Range(-MaxRandomnessXZ, MaxRandomnessXZ);
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, new Vector3(transform.localPosition.x + r, transform.localPosition.y + i * segmentLength, transform.localPosition.z + r));
        }
    }
}
