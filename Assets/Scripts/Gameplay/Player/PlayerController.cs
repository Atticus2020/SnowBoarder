using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
	[SerializeField] float torqueAmunt = 1f;
	[SerializeField] float normalSpeed = 40f;
	[SerializeField] float boostSpeed = 80f;
	[SerializeField] GameObject player;

	Rigidbody2D rb2d;
	SurfaceEffector2D surfaceEffector2D;
	public bool canMove = true;

	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
		surfaceEffector2D.speed = normalSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		Controlls();
	}

	public void Controlls()
	{
		if (canMove == true)
		{
			RotatePlayer();
			RespondToBoost();
		}
	}

	public void DisableControlls()
	{
		canMove = false;
	}


	void RespondToBoost()
	{
		if (Input.GetKey(KeyCode.W))
		{
			surfaceEffector2D.speed = boostSpeed;
			Invoke("NegateBoost", 1f);
		}
	}

	void NegateBoost()
	{
		surfaceEffector2D.speed = normalSpeed;
	}


	private void RotatePlayer()
	{
		if (Input.GetKey(KeyCode.A))
		{
			rb2d.AddTorque(torqueAmunt);
		}

		else if (Input.GetKey(KeyCode.D))
		{
			rb2d.AddTorque(-torqueAmunt);
		}
	}
}
