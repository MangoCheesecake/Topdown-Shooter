using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUpdater : MonoBehaviour 
{
	// Calls the Music Player object to check if the song should be changed.
	// Attached to the Song object.

	public MusicPlayer musicPlayer;

	void Start () 
	{
		musicPlayer = GameObject.Find ("Music Player").GetComponent<MusicPlayer>();
		musicPlayer.updateMusic ();
	}
}
