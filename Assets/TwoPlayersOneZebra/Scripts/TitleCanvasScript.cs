using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleCanvasScript : MonoBehaviour {
    public TextMeshProUGUI statusText;
	public TextMeshProUGUI startText;
	public GameObject startButton;
	private AudioSource cachedAudio;

    private int playersConnected = 0;
    private string defaultTextString = "No connection to server!";
    private string oneConnectionString = "Waiting for 2nd player...";

    private void Awake()
	{
		cachedAudio = startButton.GetComponent<AudioSource> ();
        UpdateCanvasUI();
    }

    public void OnGetPlayer()
    {
        playersConnected++;
        UpdateCanvasUI();
    }
    public void OnLosePlayer()
    {
        playersConnected--;
        UpdateCanvasUI();
    }

    private void UpdateCanvasUI()
    {
        switch (playersConnected) {
		case 0:
				statusText.gameObject.SetActive (true);
				startText.gameObject.SetActive (false);
                statusText.text = defaultTextString;
                break;
            case 1:
                statusText.gameObject.SetActive(true);
				startText.gameObject.SetActive (false);
                statusText.text = oneConnectionString;
                break;
            case 2:
                statusText.gameObject.SetActive(false);
				startText.gameObject.SetActive (true);

			// RAISE THE ALARM BUTTON
				startButton.transform.localPosition += Vector3.up * 0.01f;

			// RING THE ALARM
			this.cachedAudio.Play();
                break;
        }

    }
}
