using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
	[SerializeField] GameObject terrain;
	[SerializeField] GameObject player;

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Invoke("LoadLevel1", 2f);
			Movement0();
			
		}
	}

	public void LoadLevel1()
	{
		SceneManager.LoadScene(1);
	}

	public void Movement0()
	{
		terrain.GetComponent<SurfaceEffector2D>().speed = 0f;
		player.GetComponent<Rigidbody2D>().drag = 1000000f;
	}
}
