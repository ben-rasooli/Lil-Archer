using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] Transform _arrowPlaceholder;
	[SerializeField] GameObject _arrowPrefab;

	public void ShootArrow()
	{
		Transform arrow = Instantiate(_arrowPrefab, _arrowPlaceholder.position, _arrowPlaceholder.rotation).transform;
		arrow.GetComponent<ArrowController>().Init(this);
		arrow.GetComponent<Rigidbody>().AddForce(arrow.forward * _shootingForce);
	}
	[SerializeField] float _shootingForce;

	public void OnArrowHit(GameObject gameObject)
	{
		print(gameObject.name);
	}
}
