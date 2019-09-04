using UnityEngine;

namespace Project
{
	public class LookAtTarget : MonoBehaviour
	{
		[SerializeField] Transform _target;

		void Start()
		{
			transform.rotation = Quaternion.LookRotation(_target.position - transform.position);
		}
	} 
}
