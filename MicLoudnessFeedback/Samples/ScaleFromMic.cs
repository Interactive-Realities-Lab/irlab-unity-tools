using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{
    public AudioLoudnessDetection detector;
    public Vector3 minScale, maxScale;
    
    [Range(0f, 100f)]
    public float loudnessSensibility = 1f;
    [Range(0f, 1f)]
    public float threashold = 0.1f;
    [Range(0f, 1f)]
    public float smoothness = 0.03f;

    private Vector3 prevScale = new Vector3();

    private void Start()
    {
        prevScale = transform.localScale;
    }

    void Update()
    {
        float loudness = detector.GetLoudnessFromMic() * loudnessSensibility;

        if (loudness < threashold)
            loudness = 0;

        var newScale = Vector3.Lerp(minScale, maxScale, loudness );

        transform.localScale = Vector3.Lerp(prevScale, newScale, smoothness);

        prevScale = transform.localScale; 
    }
}
