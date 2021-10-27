using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
	[SerializeField] private GameObject star;
	[SerializeField] private float timeSpawn = 0.15f;
	private Animator anim;
	private bool isSearched = false;
	private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

	private void FixedUpdate() {
		timeCount += Time.deltaTime;

		// spawn stars
		if (isSearched && (timeCount > timeSpawn)) {
			timeCount = 0.0f;
			Instantiate(star, transform.position, Quaternion.identity);
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E)) {
			isSearched = true;
			anim.SetBool("isSearched", isSearched);
		}
	}
}
