using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Settings : MonoBehaviour
{

    // Dirty settings. Clean up later.
    [Header("Menu State")] // What is going on with our menu, is it visible? Invisible? Do I need to BLOW IT UP? Shown here.
    [SerializeField] private bool _menuActive;

    [Space]
    [Header("Game State")]
    [SerializeField] private bool gamePaused; // Probably has no use. I don't know if this is an MMO or Single-Player anymore.

    [Space]
    [Space]
    [Header("UI Theme")] // No, I'm not making specialized themes right now - This is just to hold the settings for appearance so I don't have to do it again later. Add onto as needed.
    [Space]
    [SerializeField] private GameObject _menuBackground;
    [Space]
    [Space]
    [Header("Settings")]
    [Space]

    [SerializeField] private Slider _MusicVol;
    [SerializeField] private Slider _MasterVol;
    [SerializeField] private Slider _AtmosVol;
    [SerializeField] private Button _btnApply;
    [SerializeField] private Button _btnCancel;

    private void Start()
    {
        if (!_menuBackground) this.enabled = false; // Prevent bugs if we don't have the UI active or set.
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            EscapeKeyPressed();
        }
    }

    private void EscapeKeyPressed()
    {
        _menuActive = !_menuActive;
        PauseMenu(); // References because script time.
    }

    private void PauseMenu()
    {
        if(_menuActive)  _menuBackground.SetActive(true);
        if(!_menuActive) _menuBackground.SetActive(false);
    }

    private void CancelButton()
    {
        _menuActive = false;
        PauseMenu();
    }

    private void ApplyButton()
    {
        // I do nothing right now :D!!!
    }

    // Music/Master will come after have some atmospheric sounnds / music to work with - as it involves me working with an audio mixer.

}
