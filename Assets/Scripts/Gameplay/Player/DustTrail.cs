using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem snowPS;
    private void Start()
    {
        snowPS.Stop();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Player")
        {
            snowPS.Play();
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.collider.tag == "Player")
        {
            snowPS.Stop();
        }
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
