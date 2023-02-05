using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    [Serializable]
    public class Interaction_2
    {
        private static readonly Color COLOR_GIZMO_TARGET = new Color(0f, 1f, 0f, 1f);
        private const float INFINITY = 9999f;

        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private Character_2 m_Character;
        [NonSerialized] private List<ISpatialHash> m_Interactions = new List<ISpatialHash>();

        // PROPERTIES: ----------------------------------------------------------------------------

        public IInteractive_2 Target { get; private set; }
        public bool CanInteract => !this.m_Character.Busy.AreArmsBusy && this.Target != null;

        // EVENTS: --------------------------------------------------------------------------------

        public event Action<Character_2, IInteractive_2> EventFocus;
        public event Action<Character_2, IInteractive_2> EventBlur;
        public event Action<Character_2, IInteractive_2> EventInteract;

        // INITIALIZE METHODS: --------------------------------------------------------------------

        public Interaction_2()
        {
            this.m_Character = null;
            this.Target = null;
        }
        
        internal void OnStartup(Character_2 character)
        {
            this.m_Character = character;
        }
        
        internal void AfterStartup(Character_2 character)
        { }

        internal void OnDispose(Character_2 character)
        {
            this.m_Character = character;
        }

        internal void OnEnable()
        { }

        internal void OnDisable()
        { }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public bool Interact()
        {
            if (this.Target == null) return false;
            
            this.EventInteract?.Invoke(this.m_Character, this.Target);
            this.Target.Interact(this.m_Character);

            return true;
        }
        
        // UPDATE METHODS: ------------------------------------------------------------------------
        
        internal void OnUpdate()
        {
            SpatialHashInteractions_2.Find(
                this.m_Character.transform.position,
                0,//this.m_Character.Motion.InteractionRadius,
                this.m_Interactions
            ) ;

            IInteractive_2 newTarget = null;
            float targetPriority = float.MaxValue;
            
            foreach (ISpatialHash interaction in this.m_Interactions)
            {
                if (interaction is not IInteractive_2 interactive) continue;
                //float priority = this.m_Character.Motion.InteractionMode.CalculatePriority(
                //    this.m_Character, interactive
                //);
                
                //if (priority > INFINITY) continue;
                
                if (newTarget == null)
                {
                    newTarget = interactive;
                    //targetPriority = priority;
                    continue;
                }

                //if (targetPriority > priority)
                //{
                //    newTarget = interactive;
                //    targetPriority = priority;
                //}
            }

            if (this.Target == newTarget) return;
            this.EventBlur?.Invoke(this.m_Character, this.Target);
            
            this.Target = newTarget;
            this.EventFocus?.Invoke(this.m_Character, newTarget);
        }

        // GIZMOS: --------------------------------------------------------------------------------
        
        internal void OnDrawGizmos(Character_2 character)
        {
            if (character == null) return;
            if (!character.IsPlayer) return;
            if (!Application.isPlaying) return;

            if (this.Target != null)
            {
                Gizmos.color = COLOR_GIZMO_TARGET;
                Gizmos.DrawLine(this.Target.Position, character.transform.position);
            }
        }
    }
}
