using UnityEngine;
using System.Collections.Generic;

public class SoundLookup : MonoBehaviour
{
					// <Name of Physics Material, 
	public static Dictionary<string, string> soundTable;
	
	void Start ()
	{
		soundTable = new Dictionary<string, string>();
	}
}
