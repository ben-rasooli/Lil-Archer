using UnityEngine;

public class ArrowController : MonoBehaviour
{
	Shooter _gameManager;

	public void Init(Shooter gameManager)
	{
		_gameManager = gameManager;
	}

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
		_gameManager.OnArrowHit(collision.gameObject);

		Destroy(gameObject, 10.0f);
	}
	Rigidbody _rigidbody;
}
