using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Events
{
    [CreateAssetMenu(menuName = "EventAsset")]
    public class EventAsset : ScriptableObject
    {
        [SerializeField]
        private UnityEvent<object> eventFunc;
        private bool deleteOnZeroListener;

        public static EventAsset Create(bool deleteOnZeroListener = false)
        {
            EventAsset asset = ScriptableObject.CreateInstance<EventAsset>();
            asset.deleteOnZeroListener = deleteOnZeroListener;
            return asset;
        }


        [ContextMenu("Invoke")]
        public void Invoke(object arg = null)
        {
            eventFunc.Invoke(arg);
        }

        public void AddListener(UnityAction<object> func)
        {
            if( eventFunc == null )
                eventFunc = new UnityEvent<object>();

            eventFunc.AddListener( func );
        }

        public void SetDeleteOnZeroListeners(bool value)
        {
            deleteOnZeroListener = value;
        }

        public void RemoveListener( UnityAction<object> func )
        {
            eventFunc.RemoveListener( func );

            if ( deleteOnZeroListener == true && eventFunc.GetPersistentEventCount() <= 0 )
                Destroy(this);
        }
    } 
}