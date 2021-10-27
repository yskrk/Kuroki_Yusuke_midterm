using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestImageController : MonoBehaviour
{
	[SerializeField] private Sprite spriteOpen;

	private Image imageOpen;
	private bool isSearched = false;


    // Start is called before the first frame update
    void Start()
    {
        imageOpen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSearched && Input.GetKeyDown(KeyCode.E)) {
			Debug.Log("Open!");
			imageOpen.sprite = spriteOpen;
		}
    }

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			isSearched = true;
		}
	}

}
