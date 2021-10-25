using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public PlayersDatabase players;

    public FlagsDictionary flags;

    public RolesDictionary roles;

    private static DataHolder instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (Player p in instance.players.data)
            {
                if(p != null)
                {
                    p.Initialize();
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Player GetRandomPlayer()
    {
        return instance.players.data[Random.Range(0, instance.players.data.Count)];
    }

    public static Player GetPlayerByIGN(string IGN)
    {
        return instance.players.data.Find(x => x.IGN == IGN);
    }

    public static Sprite GetSpriteFromRole(PlayerRole p)
    {
        return instance.roles.GetSpriteFromRole(p);
    }

    public static Sprite GetSpriteFromNationality(Nationality n)
    {
        return instance.flags.GetSpriteFromNationality(n);
    }
}
