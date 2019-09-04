using System;
using UnityEngine;
using Valve.VR;

namespace Project
{
	public class VRInput : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _bow;
		[SerializeField] Transform _rightHand;
		[SerializeField] Transform _leftHand;
		[SerializeField] Transform _arrowPlaceholder;
		#endregion

		#region --------------------unity messages
		void Start()
		{
			_shooter = FindObjectOfType<Shooter>();
		}

		void OnEnable()
		{
			_rightTrigger.AddOnStateUpListener(OnRightTriggerUp, SteamVR_Input_Sources.RightHand);
			_rightTrigger.AddOnChangeListener(OnRightTriggerChanged, SteamVR_Input_Sources.RightHand);
			_leftTrigger.AddOnStateUpListener(OnLefttTriggerUp, SteamVR_Input_Sources.LeftHand);
		}

		[SerializeField] SteamVR_Action_Boolean _rightTrigger;
		[SerializeField] SteamVR_Action_Boolean _leftTrigger;

		void OnDisable()
		{
		}

		void Update()
		{
			_bow.SetPositionAndRotation(_leftHand.position, _leftHand.rotation);
			_bow.Rotate(90, 0, 0);

			if(_isPullingArrow)
			{
				_arrowPlaceholder.position = _rightHand.position;
				_arrowPlaceholder.rotation = Quaternion.LookRotation(_leftHand.position - _rightHand.position, _rightHand.up);
			}
		}
		bool _isPullingArrow;
		#endregion

		#region --------------------details
		Shooter _shooter;

		void OnRightTriggerChanged(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
		{
			_isPullingArrow = newState;
			_arrowPlaceholder.gameObject.SetActive(newState);
		}
		

		void OnRightTriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
		{
			var aroowPullSize = (_leftHand.position - _rightHand.position).magnitude;
			var shootingForce = aroowPullSize / _arrowPullRange * _bowStrength;
			_shooter.ShootArrow(_leftHand.position, Quaternion.LookRotation(_leftHand.position - _rightHand.position, _rightHand.up), shootingForce);
		}
		float _arrowPullRange = 0.7f;
		[SerializeField] float _bowStrength;

		void OnLefttTriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
		{
			_arrowPullRange = (_leftHand.position - _rightHand.position).magnitude;
			print("Arrow Pull Range: " + _arrowPullRange);
		}
		#endregion
	}
}

