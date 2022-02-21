using System.Collections;
using System.Collections.Generic;
using MudioGames.Showcase.UI;
using UnityEngine;

namespace MudioGames.Showcase.Managers
{
    public enum ViewName
    {
        Start, GameOver, ScoreBoard
    }
    
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private ScoreBoardView _scoreBoardView;
        private ScoreBoardViewModel _scoreBoardViewModel ;

        [SerializeField]
        private GameOverView _gameOverView;
        
        private GameOverViewModel _gameOverViewModel; 

        [SerializeField]
        private GameStartView _gameStartView;     
        private GameStartViewModel _gameStartViewModel;

        private Dictionary<ViewName,IView> _views = new Dictionary<ViewName, IView>();

        public void Init()
        {
            _scoreBoardViewModel = new ScoreBoardViewModel();
            _scoreBoardView.Bind(_scoreBoardViewModel);
            
            _gameOverViewModel = new GameOverViewModel(_scoreBoardViewModel);
            _gameOverView.Bind(_gameOverViewModel);

            _gameStartViewModel = new GameStartViewModel();
            _gameStartView.Bind(_gameStartViewModel);
            _gameStartView.Show(true);

            _views.Add(ViewName.ScoreBoard,_scoreBoardView);
            _views.Add(ViewName.GameOver,_gameOverView);
            _views.Add(ViewName.Start,_gameStartView);
        }

        public void Navigate(ViewName name)
        {
            foreach (var view in _views)
            {
                view.Value.Show(false);
            }
            _views[name].Show(true);
        }
    }

}
