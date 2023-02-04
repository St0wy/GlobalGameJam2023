using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalGameJam
{
    public class ScreenShake : MonoBehaviour
    {
        private float shakeDuration;
        private float shakeMagnitude;
        public float defaultDuration;
        public float defaultMagnitude;
        public Vector3 initialPosition;
        private bool keepShaking = false;

        void OnEnable()
        {
            initialPosition = transform.localPosition;
        }

        void FixedUpdate()
        {
            if (shakeDuration > 0 || keepShaking)
            {
                transform.localPosition = initialPosition + Random.insideUnitSphere * (shakeMagnitude * Time.deltaTime);

                shakeDuration -= Time.deltaTime;
            }
            else
            {
                shakeDuration = 0f;
                transform.localPosition = initialPosition;
            }
        }

        public void TriggerShake(float magnitude, float duration)
        {
            shakeMagnitude = magnitude;
            shakeDuration = duration;
        }

        public void TriggerShake()
        {
            shakeMagnitude = defaultMagnitude;
            keepShaking = true;
        }

        public void StopShaking()
        {
            keepShaking = false;
            shakeDuration = 0;
        }

        [MyBox.ButtonMethod]
        public void TriggerShortShake()
        {
            shakeMagnitude = defaultMagnitude;
            shakeDuration = defaultDuration;
        }
    }
}