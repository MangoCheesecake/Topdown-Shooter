using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
	// Plays music and keeps the current song going if the a new scene loaded has the same song.
	// Attached to the Music Player object.

	public AudioSource audioSource;

	void Start () 
	{
        DontDestroyOnLoad(transform.gameObject);

        audioSource = GetComponent<AudioSource>();
		audioSource.clip = GameObject.Find ("Music").GetComponent<AudioSource> ().clip;
		audioSource.Play ();
	}

	public void updateMusic()
	{
		if (audioSource.clip != GameObject.Find ("Music").GetComponent<AudioSource> ().clip) 
		{
			audioSource.clip = GameObject.Find ("Music").GetComponent<AudioSource> ().clip;
			audioSource.Play ();
		}
	}
}
