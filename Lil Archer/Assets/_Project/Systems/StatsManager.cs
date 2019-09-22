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
        //Allows for a changeable reward multiplier ranged between 2 and 10 within the engine editor
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
        //Does stat management for a flying target
        public void OnFlyingTargetHit(FlyingTargetController target)
        {
            //Determines worth of target based on the distance between player and the flying target
            float targetWorth = (target.transform.position - _shootingOrigin.position).magnitude;
            //Multiplies the worth of the targer by an editable amount to be a reward
            targetWorth *= multiplierForFlyingTarget;
            //Adds multiplied worth to the players score
            _score += (int)targetWorth;
            //Sets the score UI to be the players current score
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
