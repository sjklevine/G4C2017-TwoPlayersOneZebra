using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleCanvasScript : MonoBehaviour {
    public TextMeshProUGUI statusText;
    public Button startButton;
    private int playersConnected = 0;
    private string defaultTextString = "No connection to server!";
    private string oneConnectionString = "Waiting for 2nd player...";

    private void Start()
    {
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
                statusText.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
                statusText.text = defaultTextString;
                break;
            case 1:
                statusText.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
                statusText.text = oneConnectionString;
                break;
            case 2:
                statusText.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
                break;
        }

    }
}
