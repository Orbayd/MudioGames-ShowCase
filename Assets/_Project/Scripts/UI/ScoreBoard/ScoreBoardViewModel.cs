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
        private void OnGiveRewards(int value)
        {
            Score = value;
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
            MessageBus.Subscribe<GiveRewardEvent>((x)=> OnGiveRewards(x.Value));
            MessageBus.Subscribe<TimeLeftEvent>((x)=> OnTimeTick(x.Value));
        }


        public void RemoveEvents()
        {
           MessageBus.UnSubscribe<GiveRewardEvent>();
           MessageBus.UnSubscribe<TimeLeftEvent>();
        }
    }
}