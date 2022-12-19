using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
	[SerializeField] float invokeTime = 0.5f;
	[SerializeField] ParticleSystem bloodPS;
	[SerializeField] GameObject player;
	[SerializeField] AudioClip crashSFX;
	[SerializeField] public int currentScene;
	bool hasCrashed = false;

	private void Start()
	{
		bloodPS.Stop();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Head" && !hasCrashed)
		{
			hasCrashed = true;
			FindObjectOfType<PlayerController>().DisableControlls();
			bloodPS.Play();
			Invoke("ReloadScene", invokeTime);
			CrashSFX();
		}
	}

	public void ReloadScene()
	{
		SceneManager.LoadScene(currentScene);
	}

	public void CrashSFX()
	{
		player.GetComponent<AudioSource>().PlayOneShot(crashSFX);
	}
}
