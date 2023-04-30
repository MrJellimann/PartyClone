using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float totalTime = 30f;
    [SerializeField]
    private TMP_Text timeText;
    [SerializeField]
    private Image gameOverImage;

    private float currentTime = 0f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
        UpdateTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isGameOver = true;
                gameOverImage.gameObject.SetActive(true);
            }

            UpdateTimeText();
        }
    }

    private void UpdateTimeText()
    {
        if (timeText != null)
        {
            timeText.text = "Time:\n" + Mathf.RoundToInt(currentTime).ToString();
        }
    }
}
