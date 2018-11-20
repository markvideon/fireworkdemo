using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour {

	private Camera cam; 
	private Vector3 init_position;

	// Spinned off into own class
	public GenerateKey explosionTriggerKey;

	private AudioSource explosionSource;
	private Rigidbody rb; 
	private ParticleSystem rocket_ps;
	private ParticleSystem burst_ps;

	private GameObject rocket_go;
	private GameObject burst_go;

	public int scale;
	public float audioDelay;
	public bool isBursting;


	// Use this for initialization
	void Start () {

		// Get intitial position
		init_position = gameObject.transform.position;

		cam = Camera.main;

		explosionTriggerKey = gameObject.GetComponent<GenerateKey> ();

		explosionSource = gameObject.GetComponent<AudioSource>();
		rb = gameObject.GetComponent<Rigidbody>();

		Transform rocket_tf = gameObject.transform.GetChild (0);
		rocket_ps = rocket_tf.GetComponent<ParticleSystem> ();
		rocket_go = rocket_tf.gameObject;

		Transform burst_tf = gameObject.transform.GetChild (1);
		burst_ps = burst_tf.GetComponent<ParticleSystem> ();
		burst_go = burst_tf.gameObject;

		// Start
		Launch();
	}


	// Update is called once per frame
	void Update () {
		if (rocket_go.activeSelf && 
			(Input.GetKeyDown (explosionTriggerKey.ReturnHardKey() )
				|| Input.GetKeyDown(KeyCode.Escape) )
			) {
			ChildToggleActive (0);
			ChildToggleActive (1);
			isBursting = true;
			Invoke ("PlayExplosionSound", audioDelay);
		}
			

		if (burst_go.activeSelf && !burst_ps.isPlaying ) {
			isBursting = false;
			ChildToggleActive (0);
			ChildToggleActive (1);
			Reset ();
		}

		if (cam.WorldToScreenPoint(gameObject.transform.position).y > (cam.pixelHeight)) {
			Reset ();
		};

	}

	/* PlayExplosionSound()
	 * 
	 * Helper function to use in combination with invoke, 
	 * Provides capacity for audio delay e.g. fireworks.
	 */

	void PlayExplosionSound() {
		explosionSource.Play ();
	}

	/* ChildToggleActive(int index)
	 * index refers to order of children in hierarchy
	 * 
	 * 	Used to 'change states' or simulate firework by changing
	 * 	active status of child objects. 
	 *
	 *	If off, turn on. If on, turn off.
	 *
	 */ 
	void ChildToggleActive(int index) {
		if (index > -1 && index < gameObject.transform.childCount) {

			// Obtain child's GameObj... Two-step using transform component
			Transform childTransform = gameObject.transform.GetChild (index);
			GameObject childGameObject = childTransform.gameObject;

			if (childGameObject.activeSelf) {
				childGameObject.SetActive (false);
			} else {
				childGameObject.SetActive (true);
			}
		}
	}

	/* Launch() 
     *
     * Adds an impulsive force to the rigidbody of this GameObject. 
     * 
     * Emits a single particle from a child particle system.
	 */
	void Launch() {
		rocket_ps.Emit (1);

		rb.AddForce (
			Random.Range (-8.5f, 8.5f),
			scale*5f, 
			0f, 
			ForceMode.Impulse
		);
	

	}

	void Reset() {
		rocket_ps.gameObject.SetActive (false);
		rb.velocity = Vector3.zero;
		gameObject.transform.position = init_position;
		rocket_ps.gameObject.SetActive (true);

		Launch ();

	}


		
}