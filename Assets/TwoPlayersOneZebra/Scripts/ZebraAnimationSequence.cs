using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ZebraAnimationSequence : MonoBehaviour
{
    public bool useLongSequence;

    public Transform bedStartPositionTransform;
    public Transform mirrorStartPositionTransform;
    public AudioSource alarmSfx;
    public VRTK_HeadsetFade fadeScript;

    private Transform thingToTeleport;
    private PhotonView photonView;

    void Start()
    {
		StartCoroutine (WaitUntilHavePlayArea ());
        photonView = this.GetComponent<PhotonView>();
    }

    void Update()
    {
        // Dev key commands...
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			StartTheIntro ();
        }
    }

	public void StartTheIntro() {
		photonView.RPC("StartNetworkedIntroSequence", PhotonTargets.AllViaServer);
	}

	IEnumerator WaitUntilHavePlayArea()
	{
		while (thingToTeleport == null) {
			thingToTeleport = VRTK.VRTK_DeviceFinder.PlayAreaTransform();
			yield return new WaitForSeconds (0.1f);
		}

        // TODO: Enable start button?  Or just pray that we have the reference by then?
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

    // TODO - Implement this
    IEnumerator DoOutroSequence()
    {
        yield return new WaitForSeconds(1.0f);
    }

    [PunRPC]
    void StartNetworkedIntroSequence()
    {
        // Start the coroutine for both players!
        if (this.useLongSequence)
        {
            StartCoroutine(DoIntroSequence());
        }
        else {
            StartCoroutine(DoJumpToMirror());
        }
    }
}