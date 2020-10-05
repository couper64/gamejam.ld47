using System;
using UnityEngine;

namespace RedHouseGames
{
	[Serializable]
	public class Rotator : MonoBehaviour
	{
		private const float MAX_SPEED = 500.00f;
		private const float SPEED_GROWTH = 10.00f;

		[SerializeField]
		private bool isRotating = false;

		[Range(-MAX_SPEED, MAX_SPEED)]
		[SerializeField]
		private float speed = 10.00f;

		[SerializeField]
		private Transform rotatee = null;

		private void Update()
		{
			if (rotatee != null && isRotating)
			{
				// Rotate.
				rotatee.Rotate(Vector3.forward, Time.deltaTime * speed, Space.Self);
			}
		}

		public void SetRandomAngle()
		{
			if (rotatee != null)
			{
				// Rotate at random angle.
				float angle = UnityEngine.Random.value * 360.00f;
				rotatee.Rotate(Vector3.forward, angle, Space.Self);
			}
		}

		public void IncreaseRotationSpeed()
		{
			// Restrict to a range.
			speed = Mathf.Clamp(speed + SPEED_GROWTH, -MAX_SPEED, MAX_SPEED);
		}
	}
}
