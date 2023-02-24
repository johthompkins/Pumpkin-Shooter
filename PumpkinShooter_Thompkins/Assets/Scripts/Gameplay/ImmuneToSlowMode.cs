using UnityEngine;

public class ImmuneToSlowMode : MonoBehaviour
{
    private float originalFixedDeltaTime;

    void Start()
    {
        // Store the original time scale of the object when it is created
        originalFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        // If the object is in slow mode, reset its time scale to the original value
        if (Time.timeScale < 1f)
        {
            Time.fixedDeltaTime = originalFixedDeltaTime;
        }
    }
}
