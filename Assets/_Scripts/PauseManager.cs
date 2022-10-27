using System;
using UnityEngine;

public class PauseManager : Singleton<PauseManager>
{
    private bool _pause = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (_pause)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                _pause = !_pause;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                _pause = !_pause;
            }
        }
    }
}