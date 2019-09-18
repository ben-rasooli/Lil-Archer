using UnityEngine;
using TMPro;

namespace Project
{
	public class StatsManager : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _shootingOrigin;
		[SerializeField] TextMeshProUGUI _scoreUI;
		#endregion

		#region --------------------interface
		public void OnTargetHit(TargetController target)
		{
			float distanceToTarget = (target.transform.position - _shootingOrigin.position).magnitude;
			_score += (int)distanceToTarget;
			_scoreUI.SetText(_score.ToString());
			print(distanceToTarget);
		}
		int _score;

        public void Reset()
        {
            _score = 0;
            _scoreUI.SetText(_score.ToString());
        }
        #endregion
    }
}
