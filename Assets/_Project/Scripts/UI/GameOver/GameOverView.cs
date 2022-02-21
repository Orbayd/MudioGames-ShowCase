using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MudioGames.Showcase.UI
{
    public class GameOverView : ViewBase<GameOverViewModel>
    {
        [SerializeField]
        private TMP_Text _txtScore;

        [SerializeField]
        private Button _btnPlay;

        protected override void OnBind(GameOverViewModel model)
        {
            _txtScore.text = model.Score.ToString();
            _btnPlay.onClick.AddListener(()=> model.ButtonPlayAgainClicked());
            
            model.PropertyChanged += (sender,property) =>
            {
                if(property.PropertyName.Equals(nameof(GameOverViewModel.Score)))
                {
                    _txtScore.text = model.Score.ToString();
                }
            };
        }
    }
}
