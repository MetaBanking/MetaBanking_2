using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    [Title("Near Character")]
    [Category("Near Character")]
    
    [Image(typeof(IconCharacter), ColorTheme.Type.Green)]
    [Description("Selects the closest interactive element to the Character")]
    
    [Serializable]
    public class InteractionModeNearCharacter_2 : TInteractionMode_2
    {
        private static readonly Vector3 GIZMO_SIZE = Vector3.one * 0.05f;
        
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private Vector3 m_Offset = new Vector3(0f, 0f, 1f);

        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        public override float CalculatePriority(Character_2 character, IInteractive_2 interactive)
        {
            Character_2 player = ShortcutPlayer.Get<Character_2>();
            if (player == null) return float.MaxValue;
            
            return Vector3.Distance(
                player.transform.TransformPoint(this.m_Offset), 
                interactive.Position
            );
        }
        
        // GIZMOS: --------------------------------------------------------------------------------

        internal override void DrawGizmos(Character_2 character)
        {
            base.DrawGizmos(character);

            Vector3 position = character.transform.TransformPoint(this.m_Offset);

            Gizmos.color = COLOR_GIZMOS;
            Gizmos.DrawCube(position, GIZMO_SIZE);
        }
    }
}