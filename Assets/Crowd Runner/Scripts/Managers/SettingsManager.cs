using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image musicButtonImage;
    [SerializeField] private Sprite soundsOnSprite;
    [SerializeField] private Sprite soundsOffSprite;
    [Header("Elements")]
    private bool soundsState = true;
    private bool musicsState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1; //save the sounds state to make it not reset
    }
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Setup()
    {
        if (soundsState)
            EnableSounds();
        else
            DisableSounds();
    }
    public void ChangeSoundsState()
    {
        if (soundsState) { DisableSounds(); }
            
        else { EnableSounds(); }
            

        soundsState = !soundsState;
        PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);

    }
    private void DisableSounds()
    {
        soundsManager.DisableSounds();
        //change the image of the soujnds button
        soundsButtonImage.sprite = soundsOffSprite;

    }
    private void EnableSounds()
    {
        soundsManager.EnableSounds();
        //change the image of the soujnds button
        soundsButtonImage.sprite = soundsOnSprite;
    }
}
