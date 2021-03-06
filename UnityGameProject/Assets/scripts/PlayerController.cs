

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 3f;
	public int maxJumps = 2;
	private int jumps; 
	public float jumpHeight = 10f;

	private bool grounded;
	public Transform groundProbe;
	public float groundProbeRadius = 0.1f;
	public LayerMask groundLayer;
	private AudioSource jumpSound;


	private Animator anim;
	private Rigidbody2D rb;

	void Start() {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		jumps = maxJumps;
		jumpSound = GetComponent<AudioSource> ();
	}

	void Update() {

		anim.SetFloat("SpeedY",rb.velocity.y);

		anim.SetBool("Land", grounded);
		anim.SetBool("Running", false);
		anim.SetBool("Jump", false);

		if (Input.GetKey (KeyCode.D)) {
			transform.localScale = new Vector3 (1, 1, 1);
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			anim.SetBool ("Running", true);
		} else if (Input.GetKey (KeyCode.A)) {
			transform.localScale = new Vector3 (-1, 1, 1);
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
			anim.SetBool ("Running", true);
		} else if (grounded) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}


		if (Input.GetKeyDown(KeyCode.Space)){
			
			if (jumps > 0) {
				jumps--;
				rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
                anim.SetBool ("Jump", true);
				jumpSound.Play();
			}
		}

		grounded = Physics2D.OverlapCircle (groundProbe.position, groundProbeRadius, groundLayer);
		if (grounded) {
			jumps = maxJumps;
		}
	}

}