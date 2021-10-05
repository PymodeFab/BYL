using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(player.name + " '' " + player.inGameName + " ''  Score : " + player.GetBaseScore() + " Current Score : " + player.GetCurrentScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
