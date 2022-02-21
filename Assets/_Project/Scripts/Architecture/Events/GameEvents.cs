using UnityEngine;

namespace MudioGames.Showcase.Events
{
    public class GameStartEvent
    {
    }

    public class PrepareRewardEvent 
    {
        public GameObject Actor {get; private set;}
        public float Score {get; private set;}

        public PrepareRewardEvent(GameObject actor, float score)
        {
            Actor = actor;
            Score = score;
        }
    }
    public class GiveRewardEvent 
    {
        public int Value {get; private set;}

        public GiveRewardEvent(int value)
        {
            Value = value;
        }
    }
    public class TimeLeftEvent 
    {
        public int Value {get; private set;}

        public TimeLeftEvent(int value)
        {
            Value = value;
        }
    }

    public class LevelProgressed
    {
        public int Value { get; private set; }

        public LevelProgressed(int value)
        {
            Value = value;
        }

    }
}