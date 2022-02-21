
using UnityEngine;
namespace MudioGames.Showcase.UI
{
    public interface IView
    {
        void Show(bool value);
    }
    public abstract class ViewBase<TModel> : MonoBehaviour , IView where TModel : ViewModelBase
    {
        protected TModel DataContex {get; private set;}

        public void Show(bool value)
        {
            this.gameObject.SetActive(value);
            OnShow(value);
        }

        protected virtual void OnShow(bool value) { }

        public void Bind(TModel model)
        {
            DataContex = model;
            OnBind(model);
            model.OnBind();
        }

        protected virtual void OnBind(TModel model) { }

        public void UnBind(TModel model)
        {
            OnUnBind(model);
            model.OnUnBind();
            DataContex = null;
        }

        protected virtual void OnUnBind(TModel model) { }
    }
}