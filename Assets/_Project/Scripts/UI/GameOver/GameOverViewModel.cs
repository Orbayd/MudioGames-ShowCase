using MudioGames.Showcase.Events;
using MudioGames.Showcase.Helpers;

namespace MudioGames.Showcase.UI
{
    public class GameOverViewModel : ViewModelBase
    {
        private ScoreBoardViewModel _scoreBoardViewModel;

        public GameOverViewModel(ScoreBoardViewModel scoreBoardViewModel)
        {
            _scoreBoardViewModel = scoreBoardViewModel;

            scoreBoardViewModel.PropertyChanged += (sender, property) =>
            {
                if (property.PropertyName.Equals(nameof(scoreBoardViewModel.Score)))
                {
                    NotifyPropertyChanged(nameof(GameOverViewModel.Score));
                }
            };
        }

        public int Score
        {
            get
            {
                return _scoreBoardViewModel.Score;
            }
        }

        public void ButtonPlayAgainClicked()
        {
            MessageBus.Publish(new GameStartEvent());
        }
    }
}
