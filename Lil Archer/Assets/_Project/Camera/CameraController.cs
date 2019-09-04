using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Project
{
	public class CameraController : MonoBehaviour
	{
        public Transform bowTransform;
		public float rotationSpeed;
        public float BowDistance = 2;
		#region --------------------unity messages
		void Start()
		{
			_transform = transform;
            bowTransform.SetParent(_transform);
            bowTransform.position = _transform.position + (_transform.forward * BowDistance);
			yaw = 0.0f;
			pitch = 0.0f;
		}

		void Update()
		{
			yaw += rotationSpeed * CrossPlatformInputManager.GetAxis("Horizontal");
			pitch -= rotationSpeed * CrossPlatformInputManager.GetAxis("Vertical");
			_transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
		}
		Transform _transform;
		float yaw;
		float pitch;
		#endregion
	}
}
