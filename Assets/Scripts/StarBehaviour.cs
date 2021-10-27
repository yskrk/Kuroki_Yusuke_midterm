using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour
{
	[SerializeField] private float vStarXMin = -3.0f;
	[SerializeField] private float vStarXMax = 3.0f;
	[SerializeField] private float vStarY = 15.0f;
	[SerializeField] private float destroyTime = 6.0f;
	private Rigidbody2D rStar;

    // Start is called before the first frame update
    void Start()
    {
		rStar = GetComponent<Rigidbody2D>();
        rStar.velocity = new Vector2(Random.Range(vStarXMin, vStarXMax), vStarY);
		Destroy(this.gameObject, destroyTime);
    }
}
