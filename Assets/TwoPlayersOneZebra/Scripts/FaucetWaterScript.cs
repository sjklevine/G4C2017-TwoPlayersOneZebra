using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetWaterScript : MonoBehaviour {
    public TaskListScript taskList;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Toothbrush"))
        {
            Debug.Log("TOOTHBRUSH IN WATER");
            taskList.CompleteTask(0);
        }
    }
}
