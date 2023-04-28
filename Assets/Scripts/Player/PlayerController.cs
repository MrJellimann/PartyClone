using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerScore))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats = null;
    [SerializeField]
    private PlayerScore playerScore = null;

    private void Awake()
    {
        if (playerStats == null)
            playerStats = GetComponent<PlayerStats>();

        if (playerScore == null)
            playerScore = GetComponent<PlayerScore>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
