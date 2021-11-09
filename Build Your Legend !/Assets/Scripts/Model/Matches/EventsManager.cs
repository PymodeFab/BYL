using System.Collections.Generic;

public static class EventsManager
{
    public static List<Event> GenerateEvents(List<Event> e1,List<Event> e2)
    {
        List<Event> result = new List<Event>();
        result.AddRange(e2);
        result.AddRange(e1);
        Event e = null;
        while (result.Count < 30)
        {
            e = DataHolder.GetRandomEvent();
            if(!e1.Contains(e) && !e2.Contains(e))
            {
                result.Add(e);
            }
        }
        return result;
    }
}