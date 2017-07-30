using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskListScript : MonoBehaviour {
	public static TaskListScript instance;
    public TextMeshProUGUI task1;
    public TextMeshProUGUI task2;
    public TextMeshProUGUI task3;
    private AudioSource cachedAudioSource;

    void Start () {
        cachedAudioSource = this.GetComponent<AudioSource>();
		instance = this;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.CompleteTask(0);
        }
    }

	public void CompleteTask(int whichTask)
    {
        // Only update if the task hasn't been already done!
        // Update the task list!
        switch (whichTask)
        {
            case 0:
                task1.text = "<s>" + task1.text + "</s>";
                break;
            case 1:
                task2.text = "<s>" + task2.text + "</s>";
                break;
            case 2:
                task3.text = "<s>" + task3.text + "</s>";
                break;
        }

        // Play the audio cue!
        cachedAudioSource.Play();
    }
}