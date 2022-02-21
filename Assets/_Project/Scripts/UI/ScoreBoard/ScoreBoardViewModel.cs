using System;
using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;

namespace MudioGames.Showcase.UI
{
    public class ScoreBoardViewModel : ViewModelBase
    {
        public int _score;
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                NotifyPropertyChanged();
            }
        }
        public int _time;
        public int Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                NotifyPropertyChanged();
            }
        }

        public int _level;
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                NotifyPropertyChanged();
            }
        }

        private void OnScoreChanged(int value)
        {
            Score = value;
        }

        private void OnLevelChanged(int value)
        {
            Level = value;
        }

        private void OnTimeTick(int value)
        {
            Time = value;
        }

        public override void OnBind()
        {
            AddEvents();
        }


        public override void OnUnBind()
        {
            RemoveEvents();
        }

        public void AddEvents()
        {
            MessageBus.Subscribe<GiveRewardEvent>((x)=> OnLevelChanged(x.Value));
            MessageBus.Subscribe<TimeLeftEvent>((x)=> OnTimeTick(x.Value));
            MessageBus.Subscribe<LevelProgressed>((x)=> OnLevelChanged(x.Value));
        }


        public void RemoveEvents()
        {
           MessageBus.UnSubscribe<GiveRewardEvent>();
           MessageBus.UnSubscribe<TimeLeftEvent>();
           MessageBus.UnSubscribe<LevelProgressed>();
        }
    }
}