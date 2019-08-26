using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Project
{
	public class CameraController : MonoBehaviour
	{
		public float rotationSpeed;

		#region --------------------unity messages
		void Start()
		{
			_transform = transform;
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
