using UnityEngine;

public class SlowMode : MonoBehaviour
{
    public float slowTimeScale = 0.5f; // The time scale to use when in slow mode
    private bool isSlowModeActive = false;

    void Update()
    {
        // Check if the "e" key is being held down
        if (Input.GetKey(KeyCode.E))
        {
            // If slow mode is not already active, set it to active and set the time scale
            if (!isSlowModeActive)
            {
                isSlowModeActive = true;
                Time.timeScale = slowTimeScale;
            }
        }
        else
        {
            // If the "e" key is not being held down and slow mode is active, set it to inactive and reset the time scale
            if (isSlowModeActive)
            {
                isSlowModeActive = false;
                Time.timeScale = 1f;
            }
        }
    }
}
