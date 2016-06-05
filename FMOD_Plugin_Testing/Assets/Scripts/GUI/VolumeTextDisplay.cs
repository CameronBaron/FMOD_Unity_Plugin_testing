using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeTextDisplay : MonoBehaviour
{
	public Slider slider;
	Text text;

	void Start ()
	{
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Display slider text as a percentage (0-100) and truncate and decimals for looks
		text.text = (slider.value * 100).ToString("F0");
	}
}
