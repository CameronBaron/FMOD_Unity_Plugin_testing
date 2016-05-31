using UnityEngine;
using System.Collections;

public class BulletDie : MonoBehaviour {

	public float lifeTime = 3.0f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer >= lifeTime)
			Destroy(gameObject);

		timer += Time.deltaTime;
	}
}
