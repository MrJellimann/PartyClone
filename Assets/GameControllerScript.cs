using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject fadeCanvas = Instantiate(Resources.Load("FadeCanvas")) as GameObject; // instantiate the FadeCanvas object from a prefab in the Resources folder
        DontDestroyOnLoad(fadeCanvas); // prevent the FadeCanvas object from being destroyed when the scene changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
