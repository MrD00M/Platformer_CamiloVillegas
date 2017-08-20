using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public int JumpSound = 0;
	public int PickUPSound = 1;

	public int count;
	public int lives;


	public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	[SerializeField]
	private AudioClip[] alternateSound;
	public AudioSource myAudioSource, gachisource;

	public Text countText;
	public Text liveText;

	void Awake ()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
		
	void Start () {

		lives = PlayerPrefs.GetInt ("PlayerLives");
		liveText.text = PlayerPrefs.GetInt ("PlayerLives").ToString ();

		count = PlayerPrefs.GetInt ("PlayerCounts");
		countText.text = PlayerPrefs.GetInt("PlayerCounts").ToString();;

	}

	void Update () {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			myAudioSource.clip = alternateSound [JumpSound];
			myAudioSource.Play ();
			jump = true;
		}


	}

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (h));

		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce (Vector2.right * h * moveForce);
		}

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}

		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}

		if (jump) {
			anim.SetTrigger ("Jump");
			rb2d.AddForce(new Vector2(0f,jumpForce));
			jump = false;
		}
	}



	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Coin")) {
			count = count +1;
			PlayerPrefs.SetInt("PlayerCounts", count);
			countText.text = PlayerPrefs.GetInt("PlayerCounts").ToString();;
			if (count == 69) {
				gachisource.Play ();
			}
			myAudioSource.clip = alternateSound [PickUPSound];
			myAudioSource.Play ();
		}
	}

	public void BajarVida()
	{
	   PlayerPrefs.SetInt ("PlayerLives", lives - 1);
	}
		
	/*public void gachimuchi()
	{
		if (count >= 69) {
			gachisource.Play ();
		}*/
	}	
