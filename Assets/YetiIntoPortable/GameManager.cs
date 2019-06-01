using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    [SerializeField]
    string MainMenuScene;

    bool isPaused;

    public GameObject PauseUI;
    public GameObject EndUI;
    public GameObject WinnerText;
    private bool gameOver = false;

    AudioSource audioSource;
    public GameObject gameSongObject;
    AudioSource gameMusic;
    public AudioClip winSong;
    public AudioClip pauseSong;
    public AudioClip readyGoClip;

    private bool playOnce = true;

	// Use this for initialization
	void Start () {
        isPaused = false;
        audioSource = GetComponent<AudioSource>();
        gameMusic = gameSongObject.GetComponent<AudioSource>();
    }

    void Update () {
	}


}
