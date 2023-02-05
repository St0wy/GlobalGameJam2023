using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalGameJam
{
	public class ScreenShake : MonoBehaviour
	{
		public float defaultDuration;
		public float defaultMagnitude;
		public Vector3 initialPosition;

		private float _shakeDuration;
		private float _shakeMagnitude;
		private bool _keepShaking = false;

		private void OnEnable()
		{
			initialPosition = transform.localPosition;
		}

		private void FixedUpdate()
		{
			if (_shakeDuration > 0 || _keepShaking)
			{
				transform.localPosition =
					initialPosition + Random.insideUnitSphere * (_shakeMagnitude * Time.deltaTime);

				_shakeDuration -= Time.deltaTime;
			}
			else
			{
				_shakeDuration = 0f;
				transform.localPosition = initialPosition;
			}
		}

		public void TriggerShake(float magnitude, float duration)
		{
			_shakeMagnitude = magnitude;
			_shakeDuration = duration;
		}

		public void TriggerShake()
		{
			_shakeMagnitude = defaultMagnitude;
			_keepShaking = true;
		}

		public void StopShaking()
		{
			_keepShaking = false;
			_shakeDuration = 0;
		}

		[MyBox.ButtonMethod]
		public void TriggerShortShake()
		{
			_shakeMagnitude = defaultMagnitude;
			_shakeDuration = defaultDuration;
		}
	}
}