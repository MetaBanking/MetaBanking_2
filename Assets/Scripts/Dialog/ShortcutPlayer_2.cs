using UnityEngine;

namespace Character_2
{
    public static class ShortcutPlayer_2
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        public static GameObject Instance { get; private set; }
        
        public static Transform Transform => Instance != null ? Instance.transform : null;

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public static TComponent Get<TComponent>() where TComponent : Component
        {
            return Instance != null ? Instance.Get<TComponent>() : null;
        }
        
        public static void Change(Character_2 character)
        {
            Instance = character != null ? character.gameObject : null;
        }
    }
}