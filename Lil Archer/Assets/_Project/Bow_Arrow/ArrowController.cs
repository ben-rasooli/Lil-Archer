using UnityEngine;

namespace Project
{
	public class ArrowController : MonoBehaviour
	{
		#region --------------------interface
		public void Fly(float shootingForce)
		{
			_trail.Clear();
			_rigidbody.useGravity = true;
			_rigidbody.isKinematic = false;
			_rigidbody.AddForce(_transform.forward * shootingForce);
		}
		TrailRenderer _trail;
		#endregion

		#region --------------------unity messages
		void Awake()
		{
			_transform = transform;
			_rigidbody = GetComponent<Rigidbody>();
			_trail = GetComponentInChildren<TrailRenderer>();
			_rigidbody.useGravity = false;
			_rigidbody.isKinematic = true;
		}

		void Update()
		{
			if (_rigidbody.velocity != Vector3.zero)
				_transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
		}
		Transform _transform;

		void OnCollisionEnter(Collision collision)
		{
            
			if (collision.gameObject.tag == "Arrow")
				return;
            if (collision.gameObject.tag != "Target")
                tag = "MissedArrow";
            
			_rigidbody.useGravity = false;
			_rigidbody.isKinematic = true;
		}
		Rigidbody _rigidbody;
		#endregion
	}
}
