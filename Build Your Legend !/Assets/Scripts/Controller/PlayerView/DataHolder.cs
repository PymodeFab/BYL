using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{

    [SerializeField] private FlagsDictionary _flags;

    [SerializeField] private RolesDictionary _roles;

    [SerializeField] private EventsDatabase _events;

    [SerializeField] private RegionsDatabase _regions;

    [SerializeField] private PlayersDatabase _freeAgents;

    private Dictionary<string, Player> playersDico;

    private Dictionary<string, Team> teamsDico;

    private Dictionary<string, Region> regionsDico;

    private Dictionary<string, Competition> compDico;


    private static DataHolder instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            foreach(MajorRegion m in _regions.data)
            {
                m.Initialize();
            }
            foreach(Player p in _freeAgents.data)
            {
                p.Initialize();
            }
            playersDico = new Dictionary<string, Player>();
            teamsDico = new Dictionary<string, Team>();
            regionsDico = new Dictionary<string, Region>();
            compDico = new Dictionary<string, Competition>();
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Player GetRandomFreeAgent()
    {
        Player p = instance._freeAgents.data[Random.Range(0, instance._freeAgents.data.Count)];
        instance.playersDico.Add(p.IGN, p);
        return p;
    }

    public static Player GetFreeAgentByIGN(string IGN)
    {
        if (instance.playersDico.ContainsKey(IGN))
        {
            return instance.playersDico[IGN];
        }
        else
        {

            Player p = instance._freeAgents.data.Find(x => x.IGN == IGN);
            if (!p.Equals(null))
            {

                instance.playersDico.Add(p.IGN, p);
            }
            return p;
        }
    }


    public static Player GetPlayerByName(string IGN)
    {
        Player p = null;
        if (instance.playersDico.ContainsKey(IGN))
        {
            return instance.playersDico[IGN];
        }
        p = GetFreeAgentByIGN(IGN);
        if (!p.Equals(null))
        {
            return p;
        }
        
        foreach(Region r in instance._regions.data)
        {
            if(r is MajorRegion)
            {
                foreach(MinorRegion mr in ((MajorRegion)r).Minors)
                {
                    foreach (Competition c in r.Competitions)
                    {
                        foreach (Team t in c.Teams)
                        {
                            p = t.GetPlayers().Find(x => x.IGN == IGN);
                            if (!p.Equals(null))
                            {
                                instance.playersDico.Add(p.IGN, p);
                                return p;
                            }
                        }
                    }
                }
            }
            foreach(Competition c in r.Competitions)
            {
                foreach(Team t in c.Teams)
                {
                    p = t.GetPlayers().Find(x => x.IGN == IGN);
                    if (!p.Equals(null))
                    {
                        instance.playersDico.Add(p.IGN, p);
                        return p;
                    }
                }
            }
        }
        return p;
    }

    public static Sprite GetSpriteFromRole(PlayerRole p)
    {
        return instance._roles.GetSpriteFromRole(p);
    }

    public static Sprite GetSpriteFromNationality(Nationality n)
    {
        return instance._flags.GetSpriteFromNationality(n);
    }

    public static Event GetRandomEvent()
    {
        return instance._events.data[Random.Range(0, instance._events.data.Count)];
    }

    public static Event GetEventByName(string name)
    {
        return instance._events.data.Find(x => x.Name == name);
    }

    public static List<MajorRegion> GetMajorRegions()
    {
        foreach(MajorRegion m in instance._regions.data)
        {
            instance.regionsDico.Add(m.name, m);
        }
        return instance._regions.data;
    }

    public static Region GetRegionByName(string name)
    {
        Region r = null;
        if (instance.regionsDico.ContainsKey(name))
        {
            return instance.regionsDico[name];
        }
        r = instance._regions.data.Find(x => x.name == name);
        if (!r.Equals(null))
        {
            instance.regionsDico.Add(name, r);
        }
        return r;

    }

    public static Team GetTeamByName(string name)
    {
        Team t = null;
        if (instance.teamsDico.ContainsKey(name))
        {
            return instance.teamsDico[name];
        }
        foreach(MajorRegion mi in instance._regions.data)
        {
            foreach(MinorRegion m in mi.Minors)
            {
                foreach (Competition c in m.Competitions)
                {
                    t = c.Teams.Find(x => x.Name == name);
                    if (!t.Equals(null))
                    {
                        instance.teamsDico.Add(name, t);
                        return t;
                    }
                }
            }
            foreach(Competition c in mi.Competitions)
            {
                t = c.Teams.Find(x => x.Name == name);
                if (!t.Equals(null))
                {
                    instance.teamsDico.Add(name, t);
                    return t;
                }
            }
        }
        return t;
    }

    public static Competition GetCompetitionByName(string name)
    {
        Competition c = null;
        if (instance.compDico.ContainsKey(name))
        {
            return instance.compDico[name];
        }
        foreach(MajorRegion mr in instance._regions.data)
        {
            c = mr.Competitions.Find(x => x.Name == name);
            if (!c.Equals(null))
            {
                instance.compDico.Add(name, c);
                return c;
            }
            foreach(MinorRegion mi in mr.Minors)
            {
                c = mi.Competitions.Find(x => x.Name == name);
                if (!c.Equals(null))
                {
                    instance.compDico.Add(name, c);
                    return c;
                }
            }
        }
        return c;
    }
}
