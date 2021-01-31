using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string main_music;

    [FMODUnity.EventRef]
    public string intro_music;

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

    [FMODUnity.EventRef]
    public string rope;

    [FMODUnity.EventRef]
    public string drop_book;

    [SerializeField] [Range(-80f, 10f)]
    private float musicVolume;
    private float sfxVolume;

    private Transform cameraPos;
    FMOD.Studio.EventInstance main_music_ev;
    FMOD.Studio.EventInstance intro_music_ev;
    FMOD.Studio.EventInstance ropeAudio;

    private bool ropeActivated = false;
    FMOD.Studio.Bus sfxBus;
    FMOD.Studio.Bus musicBus;


    // Start is called before the first frame update
    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        intro_music_ev = FMODUnity.RuntimeManager.CreateInstance(intro_music);

        main_music_ev = FMODUnity.RuntimeManager.CreateInstance(main_music);
        main_music_ev.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));


        sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        musicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        ropeAudio = FMODUnity.RuntimeManager.CreateInstance(rope);

        intro_music_ev.start();
    }

    // Update is called once per frame
    void Update()
    {
        ropeAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
    }

    public void startMainMusic()
    {
        intro_music_ev.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        main_music_ev.start();
    }

    /*Pasos para poner en la animacion*/
    public void playStep()
    {
        playOneShot(step);
    }

    /* linterna on/off */
    public void playFlashlightToggle()
    {
        playOneShot(flashlight_toggle);
    }

    /* puerta creak */
    public void playCreakyDoor()
    {
        playOneShot(creaky_door);
    }

    /* sonido para texto (TODO implementar las transiciones de letras)*/
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
        playOneShot(grab_flashlight);
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

    public void playDropBook()
    {
        playOneShot(drop_book);
    }

    /* para cuando camina entre la cuerda */
    // Es un bucle
    public void PlayRopeAudio()
    {
        if (!ropeActivated)
        {
            ropeAudio.start();
            ropeActivated = true;
        }
    }
    public void StopRopeAudio()
    {
        if (ropeActivated)
        {
            ropeAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            ropeActivated = false;
        }
    }

    public void setMusicVolume(float volume)
    {
        musicVolume = Mathf.Pow(10.0f, volume / 20f);
        musicBus.setVolume(musicVolume);
    }

    public void setSFXVolume(float volume)
    {
        sfxVolume = Mathf.Pow(10.0f, volume / 20f);
        sfxBus.setVolume(sfxVolume);
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
