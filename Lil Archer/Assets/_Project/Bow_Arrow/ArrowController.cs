using UnityEngine;

namespace Project
{
	public class ArrowController : MonoBehaviour
	{
		#region --------------------unity messages
		void Start()
		{
			_transform = transform;
			_rigidbody = GetComponent<Rigidbody>();
		}

		void Update()
		{
			if (_rigidbody.velocity != Vector3.zero)
				_transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
		}
		Transform _transform;

		void OnCollisionEnter(Collision collision)
		{
			_rigidbody.useGravity = false;
			_rigidbody.isKinematic = true;
		}
		Rigidbody _rigidbody;
		#endregion
	}
}
