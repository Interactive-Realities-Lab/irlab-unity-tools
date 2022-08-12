using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IRLab.Tools.MicLoudness
{
    public class AudioLoudnessDetection : MonoBehaviour
    {
        public int sampleWindow = 64;
        private AudioClip micClip;
        // Start is called before the first frame update
        void Start()
        {
            MicToAudioClip();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void MicToAudioClip()
        {
            string micName = Microphone.devices[0];
            micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
        }

        public float GetLoudnessFromMic()
        {
            return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
        }

        public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
        {
            int startPosition = clipPosition - sampleWindow;

            if (startPosition < 0)
                return 0;

            float[] waveData = new float[sampleWindow];
            clip.GetData(waveData, startPosition);

            //compute loudness
            float totalLoudness = 0;
            for (int i = 0; i < sampleWindow; i++)
            {
                totalLoudness += Mathf.Abs(waveData[i]);
            }

            return totalLoudness / sampleWindow;
        }
    }
}