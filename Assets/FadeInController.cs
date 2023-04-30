using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{
    public float fadeDuration = 1.0f; // the duration of the fade effect, in seconds
    public Image fadeImage; // the image component that will be used for fading

    private float fadeTimer; // a timer that counts down the duration of the fade effect

    void Start()
    {
        fadeImage.color = new Color(1f, 1f, 1f, 1f); // set the image to fully opaque at the start
        fadeTimer = fadeDuration; // initialize the timer to the full duration of the fade effect
    }

    void Update()
    {
        fadeTimer -= Time.deltaTime; // count down the timer based on the time that has elapsed since the last frame

        if (fadeTimer <= 0f) // if the fade effect is complete
        {
            fadeImage.color = new Color(1f, 1f, 1f, 0f); // set the image to fully transparent
            Destroy(this.gameObject); // destroy the FadeCanvas object to remove the fade effect from the scene
        }
        else // if the fade effect is still in progress
        {
            float alpha = fadeTimer / fadeDuration; // calculate the alpha value based on the remaining time
            fadeImage.color = new Color(1f, 1f, 1f, alpha); // set the alpha value of the image accordingly
        }
    }
}
