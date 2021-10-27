using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControllerAlt : MonoBehaviour
{
	[SerializeField] private Sprite spriteOpen;
	[SerializeField] private GameObject star;
	[SerializeField] private float timeSpawn = 0.15f;

	private SpriteRenderer sRendererChest;
	private bool canSearch = false;
	private bool isSearched = false;
	private float timeCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        sRendererChest = GetComponent<SpriteRenderer>();
    }

	private void FixedUpdate() {
		timeCount += Time.deltaTime;

		if (canSearch && Input.GetKeyDown(KeyCode.E)) {
			// Debug.Log("Open!");
			isSearched = true;
			sRendererChest.sprite = spriteOpen;
		}

		// spawn stars
		if (isSearched && (timeCount > timeSpawn)) {
			timeCount = 0.0f;
			Instantiate(star, transform.position, Quaternion.identity);
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			// Debug.Log("Staying");
			canSearch = true;
		}
	}
}
