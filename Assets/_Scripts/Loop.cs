using System.Collections.Generic;
using UnityEngine;

namespace RedHouseGames
{
	public class Loop : MonoBehaviour
	{
		[Header("Set it in Editor")]
		[SerializeField]
		private Rotator playerRotator = null;

		[Header("Set it in Editor")]
		[SerializeField]
		private List<Rotator> targetRotators = null;

		[Header("Set it in Editor")]
		[SerializeField]
		private Animator animator = null;

		#region Properties

		public Rotator PlayerRotator
		{
			private set
			{
				playerRotator = value;
			}

			get
			{
				return playerRotator;
			}
		}

		public List<Rotator> TargetRotators
		{
			private set
			{
				targetRotators = value;
			}

			get
			{
				return targetRotators;
			}
		}

		public Animator Animator
		{
			private set
			{
				animator = value;
			}

			get
			{
				// It should be attached.
				if (animator == null)
				{
					animator = GetComponent<Animator>();
				}

				return animator;
			}
		}

		#endregion

		public void OnEndAnimationNext()
		{
			// Set player.
			playerRotator.IncreaseRotationSpeed();

			// Set targets.
			foreach (var item in targetRotators)
			{
				item.SetRandomAngle();
			}
		}
	}
}
