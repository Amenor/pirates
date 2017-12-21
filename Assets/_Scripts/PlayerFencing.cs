using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerFencing : MonoBehaviour
{
	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;

	public Text text;
//	public float range = 100f;
//	public LineRenderer line;


	float timer;
	//Ray shootRay = new Ray();
//	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem bloodParticles;
	//LineRenderer gunLine;
	AudioSource swordAudio;
//	Light gunLight;
	float effectsDisplayTime = 0.2f;
	Animator anim;
	bool collided = false;
	GameObject enemyColl;


	void Start(){
		anim =  gameObject.GetComponent<Animator>();

	}

	void Awake ()
	{
		shootableMask = LayerMask.GetMask ("Shootable");
		bloodParticles = GetComponent<ParticleSystem> ();
		//gunLine = GetComponent <LineRenderer> ();
		//gunLine = line;
		swordAudio = GetComponent<AudioSource> ();
		//gunLight = GetComponent<Light> ();
		anim = GetComponent<Animator>();
	}


	void Update ()
	{
		timer += Time.deltaTime;
		//	gunLine.enabled = true;
		if(Input.GetMouseButtonDown(1) && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			//Attack ();
			timer = 0f;

			swordAudio.Play ();
			text.text = "xxxxxxxx";

			anim.SetTrigger ("AttackSword");
			if(collided){
				Debug.Log ("collision");

				bloodParticles.Stop ();
				bloodParticles.Play ();


				EnemyHealth enemyHealth = enemyColl.GetComponent <EnemyHealth> ();
				if(enemyHealth != null)
				{
					enemyHealth.TakeDamage (damagePerShot, gameObject.transform.position);
				}
			}
		
		}


	}



	void onCollisionEnter(Collision col){
		text.text = "AAAAAA";
		if (col.gameObject.tag == "Enemy"){
		//	text.text = "AAAAAA";
			collided = true;
			enemyColl = col.gameObject;
			/*
			bloodParticles.Stop ();
			bloodParticles.Play ();


			EnemyHealth enemyHealth = col.gameObject.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, gameObject.transform.position);
			}
			*/
		}
	}


	void Attack ()
	{
		timer = 0f;

		swordAudio.Play ();

		//gunLight.enabled = true;

		bloodParticles.Stop ();
		bloodParticles.Play ();




		//  gunLine.enabled = true;
	//	gunLine.enabled = false;
	//	gunLine.SetPosition (0, transform.position);

	//	shootRay.origin = transform.position;
	//	shootRay.direction = transform.forward;

	/*	if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}*/
	}
}
