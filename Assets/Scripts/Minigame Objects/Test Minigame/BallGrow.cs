using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrow : MonoBehaviour
{
    [SerializeField] float animationDuration = 1.0f;
    float animationTimer = 0f;
    float _scale = 0f;

    void Awake()
    {
        this.gameObject.transform.localScale = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animationTimer < animationDuration)
        {
            animationTimer += Time.deltaTime;
        }

        _scale = Mathf.Lerp(0f, 1f, animationTimer / animationDuration);
        this.gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
    }
}
