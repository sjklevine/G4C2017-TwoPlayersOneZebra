using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskListScript : MonoBehaviour {

    public TextMeshProUGUI task1;
    public TextMeshProUGUI task2;
    public TextMeshProUGUI task3;
    private AudioSource cachedAudioSource;
    private int tasksComplete = 0;

    void Start () {
        cachedAudioSource = this.GetComponent<AudioSource>();	    	
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.CompleteTask();
        }
    }

	public void CompleteTask()
    {
        // Play the audio cue!
        cachedAudioSource.Play();

        // Update the task list!
        switch (tasksComplete)
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

        // Count the completion!
        this.tasksComplete++;
    }
}
