using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBrick : MonoBehaviour
{

	SpriteRenderer sr;
	BoxCollider2D bc;

	ParticleSystem part;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		bc = GetComponent<BoxCollider2D>();
		part = GetComponentInChildren<ParticleSystem>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ball")
		{
			part.Play();
			sr.enabled = false;
			bc.enabled = false;
			StartCoroutine(Particle());
		}
	}

	private IEnumerator Particle()
	{
		yield return new WaitForSeconds(part.main.startLifetime.constantMax);
		Destroy(gameObject);
	}
}
