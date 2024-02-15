using System.Collections;
using UnityEngine;

public class GreenBrick : MonoBehaviour
{
	SpriteRenderer sr;
	BoxCollider2D bc;
	ParticleSystem part;

	[SerializeField]
	GameObject blue;

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
			Instantiate(blue, transform.position, Quaternion.identity);
			StartCoroutine(Particle());
		}
	}


	private IEnumerator Particle()
	{
		yield return new WaitForSeconds(part.main.startLifetime.constantMax);
		Destroy(gameObject);
	}





}
