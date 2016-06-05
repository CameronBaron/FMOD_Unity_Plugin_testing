using UnityEngine;

// Counter to destroy onject after a specified time has passed.
public class BulletDie : MonoBehaviour
{
	public float lifeTime = 3.0f;
	private float timer = 0;
	
	void Update ()
	{
		if (timer >= lifeTime)
			Destroy(gameObject);

		timer += Time.deltaTime;
	}
}
