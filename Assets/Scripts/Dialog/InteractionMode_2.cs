using System;
using UnityEngine;

namespace Character_2
{
    [Serializable]
    public class InteractionMode_2
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeReference] private TInteractionMode_2 m_InteractionMode;

        // CONSTRUCTOR: ---------------------------------------------------------------------------

        public InteractionMode_2()
        {
            this.m_InteractionMode = new InteractionModeNearCharacter_2();
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public float CalculatePriority(Character_2 character, IInteractive_2 interactive)
        {
            return this.m_InteractionMode?.CalculatePriority(character, interactive) ?? float.MaxValue;
        }

        // DRAW GIZMOS: ---------------------------------------------------------------------------

        public void DrawGizmos(Character_2 character)
        {
            this.m_InteractionMode?.DrawGizmos(character);
        }
    }
}