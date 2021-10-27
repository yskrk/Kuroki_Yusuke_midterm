using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
	[SerializeField] GameObject star;
	private Animator anim;
	private bool isSearched = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

	private void FixedUpdate() {
		// spawn stars
		// while (isSearched) {
		// 	Instantiate(star, transform.position, Quaternion.identity);
		// }
	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.E)) {
			isSearched = true;
			anim.SetBool("isSearched", isSearched);
		}
	}
}
