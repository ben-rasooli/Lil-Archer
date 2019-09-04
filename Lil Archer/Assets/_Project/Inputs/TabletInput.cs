using UnityEngine;
using UnityEngine.UI;

namespace Project
{
	public class TabletInput : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _bow;
		[SerializeField] Transform _shootingOrigin;
		#endregion

		#region --------------------unity messages
		void Start()
		{
			_shooter = FindObjectOfType<Shooter>();
		}

		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				Vector2 touchPosition = getTouchPositionWithInvertedX();

				if (isTouchWithinShootingBoundary(touchPosition))
				{
					Vector2 shootingTouchOrigin = _shootingTouchArea.rectTransform.pivot;
					Vector2 touchVector = touchPosition - shootingTouchOrigin;
					float angle = Vector2.Angle(Vector2.left, touchVector);

                    _shootingOrigin.rotation = Quaternion.Euler(-angle, _bow.eulerAngles.y, _bow.eulerAngles.z);
				}
			}

			if (Input.GetMouseButtonUp(0))
			{
				Vector2 touchPosition = getTouchPositionWithInvertedX();

				if (isTouchWithinShootingBoundary(touchPosition))
				{
					Vector2 shootingTouchOrigin = _shootingTouchArea.rectTransform.pivot;
					Vector2 touchVector = touchPosition - shootingTouchOrigin;
					float angle = Vector2.Angle(Vector2.left, touchVector);
					//Quaternion direction = Quaternion.AngleAxis(-angle, _shootingOrigin.right);
					Quaternion direction = _shootingOrigin.rotation;

					float shootingForce = ((touchPosition - shootingTouchOrigin).magnitude / _shootingTouchArea.rectTransform.rect.width) * _bowStrength;

					_shooter.ShootArrow(_shootingOrigin.position, direction, shootingForce);
				}
			}

		}
		[SerializeField] Image _shootingTouchArea;
		[SerializeField] float _bowStrength;
		#endregion

		#region --------------------details
		Shooter _shooter;

		bool isTouchWithinShootingBoundary(Vector2 touchPosition)
		{
			var areaTransform = _shootingTouchArea.rectTransform;
			Vector2 touchPositionPlusOffset = new Vector2(
				touchPosition.x - areaTransform.anchoredPosition.x,
				touchPosition.y - areaTransform.anchoredPosition.y);

			return areaTransform.rect.Contains(touchPositionPlusOffset);
		}

		Vector2 getTouchPositionWithInvertedX()
		{
			return new Vector2(-Mathf.Abs(Input.mousePosition.x - Screen.width), Input.mousePosition.y);
		}
		#endregion
	}
}
