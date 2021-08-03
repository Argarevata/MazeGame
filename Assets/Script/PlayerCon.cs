using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {

	public Rigidbody2D myBody;
	public float speed;
	public JoystickCon joy;
	public GameObject loseScreen, winScreen, jumpScareScreen;
	public int useJumpScare;
	public AudioSource bgm, winSFX, loseSFX, screamSFX;

	//PLAYERPREFS
	// - jumpscare int 1 == withJumpscare   0 == NoJumpscare
	// - level   level yg sudah diunlock START WITH 0

	void Start () {
		Time.timeScale = 1;
		myBody = GetComponent<Rigidbody2D> ();
		joy = FindObjectOfType<JoystickCon> ();
		useJumpScare = PlayerPrefs.GetInt("jumpscare");
	}
	
	void Update () {

		myBody.velocity = new Vector2 (joy.inputVector.x * speed, joy.inputVector.z * speed);

		if (Input.GetKeyDown(KeyCode.X))
		{
			if (useJumpScare == 0)
			{
				useJumpScare = 1;
			}
			else
			{
				useJumpScare = 0;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Obstacle")
		{
			Time.timeScale = 0;
			bgm.Pause();
			if (useJumpScare == 1)
			{
				jumpScareScreen.SetActive(true);
				screamSFX.Play();
			}
			else
			{
				loseScreen.SetActive(true);
				loseSFX.Play();
			}
		}
		else if (otherCollider.tag == "Finish")
		{
			winScreen.SetActive(true);
			Time.timeScale = 0;
			bgm.Pause();
			winSFX.Play();

			string thisLevelName = Application.loadedLevelName;
			int levelIdx = int.Parse(thisLevelName);
			if (PlayerPrefs.GetInt("level") < levelIdx)
			{
				PlayerPrefs.SetInt("level", levelIdx);
			}
		}
	}
}
