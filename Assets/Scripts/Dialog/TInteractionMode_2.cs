using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    [Title("Interaction Mode")]
    
    [Serializable]
    public abstract class TInteractionMode_2
    {
        protected static readonly Color COLOR_GIZMOS = new Color(0f, 1f, 0f, 0.5f);
        
        // PUBLIC METHODS: ------------------------------------------------------------------------

        public abstract float CalculatePriority(Character_2 character, IInteractive_2 interactive);

        // DRAW GIZMOS: ---------------------------------------------------------------------------

        internal virtual void DrawGizmos(Character_2 character)
        { }
    }
}