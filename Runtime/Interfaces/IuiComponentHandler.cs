using UnityEngine;
using UnityEngine.UI;

namespace Craglex.SimpleUI{
    public interface IUiComponentHandler<T> where T : Graphic
    {
        public T Value{get; set;}

        public void Init(){
            Value = GameObject.FindFirstObjectByType<T>();
        }
    }
}