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
			GameObject arrow = spawnArrow(shootingOrigin, direction);
			arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * shootingForce);
		}
		#endregion

		#region --------------------unity messages
		void Start()
		{
			initializeArrowPool();
		}
		#endregion

		#region --------------------details
		GameObject spawnArrow(Vector3 shootingOrigin, Quaternion direction)
		{
			GameObject result;

			if (_currentArrowIndex >= _arrowPoolSize)
				_currentArrowIndex = 0;

			result = _arrowPool[_currentArrowIndex];
			_currentArrowIndex++;


			result.transform.SetPositionAndRotation(shootingOrigin, direction);
			result.SetActive(true);

			return result;
		}
		[SerializeField] int _arrowPoolSize;
		int _currentArrowIndex;
		List<GameObject> _arrowPool;

		void initializeArrowPool()
		{
			for (int i = 0; i < _arrowPoolSize; i++)
			{
				GameObject arrow = Instantiate(_arrowPrefab);
				arrow.SetActive(false);
				_arrowPool.Add(arrow);
			}

			_currentArrowIndex = 0;
		}
		#endregion
	}
}