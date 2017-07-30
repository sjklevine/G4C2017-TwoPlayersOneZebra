using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ZebraAnimationSequence : MonoBehaviour
{
    public bool startImmediately;

    public Transform bedStartPositionTransform;
    public Transform mirrorStartPositionTransform;
    public AudioSource alarmSfx;
    public VRTK_HeadsetFade fadeScript;

    private Transform thingToTeleport;

    void Start()
    {
		StartCoroutine (WaitUntilHavePlayArea ());
    }

    void Update()
    {
        // Dev key commands...
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(DoIntroSequence());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(DoJumpToMirror());
        }
    }

	IEnumerator WaitUntilHavePlayArea()
	{
		while (thingToTeleport == null) {
			thingToTeleport = VRTK.VRTK_DeviceFinder.PlayAreaTransform();
			yield return new WaitForSeconds (0.1f);
		}
		if (startImmediately) {
			StartCoroutine(DoIntroSequence());
		}
	}

    IEnumerator DoIntroSequence()
    {
        // (Fade from black will happen instantly outside this script)
        // Warp the player to position X (standing next to bed)
        thingToTeleport.position = bedStartPositionTransform.position;
        thingToTeleport.rotation = bedStartPositionTransform.rotation;

        // Play alarm sfx
        alarmSfx.Play();

        // Wait for x seconds
        yield return new WaitForSeconds(2.0f);

        // Fade to black
        float fadeTime = 1.0f;
        fadeScript.Fade(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        // Warp the player to position Y (mirror)
        thingToTeleport.position = mirrorStartPositionTransform.position;
        thingToTeleport.rotation = mirrorStartPositionTransform.rotation;

        // Fade from black
        float unfadeTime = 1.0f;
        fadeScript.Unfade(unfadeTime);
    }

    IEnumerator DoJumpToMirror()
    {
        // Fade to black
        float fadeTime = 1.0f;
        fadeScript.Fade(Color.black, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        // Warp the player to position Y (mirror)
        thingToTeleport.position = mirrorStartPositionTransform.position;
        thingToTeleport.rotation = mirrorStartPositionTransform.rotation;

        // Fade from black
        float unfadeTime = 1.0f;
        fadeScript.Unfade(unfadeTime);
    }

    IEnumerator DoOutroSequence()
    {
        yield return new WaitForSeconds(1.0f);
    }


}