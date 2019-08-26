using System.Collections.Generic;
using UnityEngine;

namespace Project
{
	public class Shooter : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] GameObject _arrowPrefab;
		#endregion

		#region --------------------interface
		public void ShootArrow(Vector3 shootingOrigin, Quaternion direction, float shootingForce)
		{
			ArrowController arrow = spawnArrow(shootingOrigin, direction);

			arrow.Fly(shootingForce);
		}
		#endregion

		#region --------------------unity messages
		void Start()
		{
			initializeArrowPool();
		}
		#endregion

		#region --------------------details
		ArrowController spawnArrow(Vector3 shootingOrigin, Quaternion direction)
		{
			GameObject result;

			if (_currentArrowIndex >= _arrowPoolSize)
				_currentArrowIndex = 0;

			result = _arrowPool[_currentArrowIndex];
			_currentArrowIndex++;
			
			result.transform.SetPositionAndRotation(shootingOrigin, direction);

			return result.GetComponent<ArrowController>();
		}
		[SerializeField] int _arrowPoolSize;
		int _currentArrowIndex;
		List<GameObject> _arrowPool = new List<GameObject>();

		void initializeArrowPool()
		{
			for (int i = 0; i < _arrowPoolSize; i++)
			{
				GameObject arrow = Instantiate(_arrowPrefab);
				_arrowPool.Add(arrow);
			}

			_currentArrowIndex = 0;
		}
		#endregion
	}
}