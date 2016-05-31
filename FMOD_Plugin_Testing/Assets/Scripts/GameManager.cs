using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
	public GameObject player;
	public Canvas pauseCanvas;

	private bool paused = false;
	// Use this for initialization
	void Start ()
	{
		pauseCanvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If button is pressed then activate pause menu and pause game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!paused)
			{
				Time.timeScale = 0;
				player.GetComponent<FirstPersonController>().enabled = false;
				paused = true;
				pauseCanvas.gameObject.SetActive(true);
				Cursor.visible = true;
				return;
			}
			Time.timeScale = 1;
			player.GetComponent<FirstPersonController>().enabled = true;
			paused = false;
			pauseCanvas.gameObject.SetActive(false);
			Cursor.visible = false;
		}
	}
}
