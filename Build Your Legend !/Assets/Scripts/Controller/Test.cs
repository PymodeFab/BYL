using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(player.BirthdayToString);
        //Debug.Log(player.GetCurrentScore());
        Debug.Log(player.GetBaseScore());
        Debug.Log(player.GetPotential());
        Debug.Log(player.CalculateAge(System.DateTime.Now));
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(player.CalculateAge(System.DateTime.Now));
    }
}
