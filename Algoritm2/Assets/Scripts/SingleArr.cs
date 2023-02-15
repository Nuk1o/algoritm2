using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SinglArr
{
    public class SingleArr : MonoBehaviour, IPointerClickHandler
    {
        private static readonly SingleArr instance = new SingleArr();
 
        private List<GameObject> _blocks { get; set; }

        private SingleArr()
        {

        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
 
        public static SingleArr GetInstance()
        {
            return instance;
        }
    }
}

