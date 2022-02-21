using TMPro;
using UnityEngine;

namespace MudioGames.Showcase.UI
{
    public class ScoreBoardView : ViewBase<ScoreBoardViewModel>
    {
        [SerializeField]
        private TMP_Text _txtScore;

        [SerializeField]
        private TMP_Text _txtTime;

        [SerializeField]
        private TMP_Text _txtLevel;

        protected override void OnBind(ScoreBoardViewModel model)
        {
            _txtScore.text = model.Score.ToString();
            model.PropertyChanged += (sender,property)=>
            {
                if(property.PropertyName.Equals(nameof(model.Score)))
                {
                    _txtScore.text = "Score: " + model.Score.ToString();
                }

                if(property.PropertyName.Equals(nameof(model.Time)))
                {
                    _txtTime.text = "Time: " + model.Time.ToString();
                }

                 if(property.PropertyName.Equals(nameof(model.Level)))
                {
                    _txtTime.text = "Level: " +  model.Level.ToString();
                }
            };
        }
    }
}