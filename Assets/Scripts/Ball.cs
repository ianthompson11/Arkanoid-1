using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

	public Rigidbody2D rigidBody2D;
	public float speed = 300;

	private Vector2 velocity;

	Vector2 startPosition;

	public AudioSource audioSource;
	public AudioClip playerSound, brickSound;


	void Start(){

		startPosition = transform.position; 
		ResetBall();
	}

	private void OnCollisionEnter2D(Collision2D collision){
    
		if (collision.gameObject.CompareTag("DeadZone")){
			FindObjectOfType<GameManager>().LoseHealth();
		}

		if (collision.gameObject.GetComponent<Player>()){

			audioSource.clip = playerSound;
			audioSource.Play();

			// Punto de impacto relativo
			float hitPoint = transform.position.x - collision.transform.position.x;
			float paddleWidth = collision.collider.bounds.size.x;

			float relativeImpact = hitPoint / (paddleWidth / 2); // Normalizado entre -1 y 1

			Vector2 newDirection = new Vector2(relativeImpact, 1).normalized;
			rigidBody2D.linearVelocity = newDirection * rigidBody2D.linearVelocity.magnitude;
		}

		if (collision.gameObject.GetComponent<Brick>()){
			audioSource.clip = brickSound;
			audioSource.Play();
		}
	}

	void Update(){
		Vector2 vel = rigidBody2D.linearVelocity;

		// Prevenir velocidad X casi 0
		if (Mathf.Abs(vel.x) < 0.2f){
			vel.x = 0.3f * Mathf.Sign(Random.Range(-1f, 1f));
		}

		// Prevenir velocidad Y casi 0 (menos com�n, pero �til)
		if (Mathf.Abs(vel.y) < 0.2f){
			vel.y = 0.3f * Mathf.Sign(Random.Range(-1f, 1f));
		}

		// Reaplicar la velocidad corregida, manteniendo la magnitud original
		rigidBody2D.linearVelocity = vel.normalized * rigidBody2D.linearVelocity.magnitude;
	}


	public void ResetBall(){
		transform.position = startPosition;
		rigidBody2D.linearVelocity=Vector2.zero;
		velocity.x = Random.Range(-1f,1f);
		velocity.y = 1;
		rigidBody2D.AddForce(velocity*speed);

	}

}
