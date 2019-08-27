using UnityEngine;

namespace Project
{
	public class StatsManager : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _shootingOrigin;
		#endregion

		#region --------------------interface
		public void OnTargetHit(TargetController target)
		{
			float distanceToTarget = (target.transform.position - _shootingOrigin.position).magnitude;
			print(distanceToTarget);
		}
		#endregion
	}
}
