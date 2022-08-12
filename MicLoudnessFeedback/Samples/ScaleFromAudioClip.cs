using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudioClip : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale, maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100f;
    public float threashold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;

        if (loudness < threashold)
            loudness = 0;
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
