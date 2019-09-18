using UnityEngine;
using TMPro;
using System;
using System.Collections;

namespace Project
{
	public class TargetController : MonoBehaviour
	{
		#region --------------------dependencies
		[SerializeField] Transform _shootingOrigin;
		StatsManager _statsManager;
		TextMeshProUGUI _textUI;
        ParticleSystem _awesomeExplosion;
		#endregion

		#region --------------------unity messages
		IEnumerator Start()
		{
			_statsManager = FindObjectOfType<StatsManager>();
			_textUI = GetComponentInChildren<TextMeshProUGUI>();
            _awesomeExplosion = GetComponentInChildren<ParticleSystem>();
			yield return null;
			_textUI.text = String.Format("{0:0.00}", (_shootingOrigin.position - transform.position).magnitude) + "m";
		}

		void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag == "Arrow")
			{
				_statsManager.OnTargetHit(this);
                _awesomeExplosion.Play();

			}
		}
		#endregion
	}
}
