using UnityEngine;

namespace Project
{
	public class TargetController : MonoBehaviour
	{
		#region --------------------dependencies
		StatsManager _statsManager;
		#endregion

		#region --------------------unity messages
		void Start()
		{
			_statsManager = FindObjectOfType<StatsManager>();
		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Arrow")
			{
				_statsManager.OnTargetHit(this);
			}
		}
		#endregion
	}
}
