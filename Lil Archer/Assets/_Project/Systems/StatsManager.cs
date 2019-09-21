using UnityEngine;
using TMPro;

namespace Project
{
	public class StatsManager : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _shootingOrigin;
		[SerializeField] TextMeshProUGUI _scoreUI;
       
        //Jack addition
        [Range(2, 10)]
        public int multiplierForFlyingTarget;

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

        //Jack addition
        public void OnFlyingTargetHit(FlyingTargetController target)
        {
            float targetWorth = (target.transform.position - _shootingOrigin.position).magnitude;
            targetWorth *= multiplierForFlyingTarget;
            _score += (int)targetWorth;
            _scoreUI.SetText(_score.ToString());
        }

        public void Reset()
        {
            _score = 0;
            _scoreUI.SetText(_score.ToString());
        }
        #endregion
    }
}
