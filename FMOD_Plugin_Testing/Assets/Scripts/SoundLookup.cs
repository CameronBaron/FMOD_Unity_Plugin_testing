using UnityEngine;
using System.Collections.Generic;

public class SoundLookup : MonoBehaviour
{
	public static readonly SoundLookup _instance = new SoundLookup();

					// <Name of Physics Material, 
	public static Dictionary<string, FMOD.Studio.EventInstance> soundTable;
	
	SoundLookup() {}


	void Start ()
	{
		soundTable = new Dictionary<string, FMOD.Studio.EventInstance>();
	}

	FMOD.Studio.EventInstance GetSoundEvent(string key)
	{
		// If sound is not in dictionary return error
		if (!soundTable.ContainsKey(key))
		{
			Debug.LogError("Error: " + key + " not found");
		}

		return soundTable[key];
	}
}
