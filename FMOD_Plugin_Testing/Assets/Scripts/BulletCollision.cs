using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		PhysicMaterial otherPhysicsMat = col.gameObject.GetComponent<PhysicMaterial>();

		// Use a lookup table and have preset sounds to use for collisions with different materials
	}
}
