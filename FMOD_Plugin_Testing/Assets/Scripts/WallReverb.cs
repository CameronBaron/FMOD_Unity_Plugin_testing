using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class WallReverb : MonoBehaviour
{
	FMOD.Geometry f_geometry;
	FMOD.System lowlevelsystem;

	// Use this for initialization
	void Start ()
	{
		lowlevelsystem = FMODUnity.RuntimeManager.LowlevelSystem;
		uint version;
		lowlevelsystem.getVersion(out version);
		lowlevelsystem.createGeometry(1, 5, out f_geometry);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
