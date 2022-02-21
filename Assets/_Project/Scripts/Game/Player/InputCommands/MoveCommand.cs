
using System;


namespace MudioGames.Showcase.GamePlay
{
    public interface IBehaviourCommand
    {
        void Execute();
    }
    public enum CommandType
    {
        Move, Shoot
    }
    public class BehaviourCommand : IBehaviourCommand
    {
        private Action _callback;

        public BehaviourCommand(Action callback)
        {
            _callback = callback;
        }

        public void Execute()
        {
            _callback?.Invoke();
        }
    }
}