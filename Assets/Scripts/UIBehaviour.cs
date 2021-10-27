using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
	
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DisableUI", 7.0f);
    }

	private void DisableUI () {
		this.gameObject.SetActive(false);
	}
}
