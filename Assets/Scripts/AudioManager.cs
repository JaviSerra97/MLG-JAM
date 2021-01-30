using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string step;

    [FMODUnity.EventRef]
    public string flashlight_toggle;

    [FMODUnity.EventRef]
    public string creaky_door;

    [FMODUnity.EventRef]
    public string typewriter;

    [FMODUnity.EventRef]
    public string flicker_light;

    [FMODUnity.EventRef]
    public string grab;

    [FMODUnity.EventRef]
    public string grab_flashlight;

    [FMODUnity.EventRef]
    public string knife;

    [FMODUnity.EventRef]
    public string glass_break;

    [FMODUnity.EventRef]
    public string ui_next;

    private Transform cameraPos;
    FMOD.Studio.EventInstance musicEV;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playStep()
    {
        playOneShot(step);
    }

    public void playFlashlightToggle()
    {
        playOneShot(flashlight_toggle);
    }

    public void playCreakyDoor()
    {
        playOneShot(creaky_door);
    }

    public void playTypewriter()
    {
        playOneShot(typewriter);
    }

    // This is a loop
    public void playFlickerLight()
    {
        playOneShot(flicker_light);
    }

    public void playGrab()
    {
        playOneShot(grab);
    }

    public void playGrabFlashlight()
    {
        playOneShot(grabFlashlight);
    }

    public void playKnife()
    {
        playOneShot(knife);
    }

    public void playGlassBreak()
    {
        playOneShot(glass_break);
    }

    public void playUINext()
    {
        playOneShot(ui_next);
    }

    private void playOneShot(string name)
    {
        FMOD.Studio.EventInstance fmodEvent;
        fmodEvent = FMODUnity.RuntimeManager.CreateInstance(name);
        fmodEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
        fmodEvent.start();
        fmodEvent.release();
    }
}
