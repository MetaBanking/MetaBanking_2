using System;

namespace Character_2
{
    [Serializable]
    public class Jump_2
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private Character_2 m_Character;
        [NonSerialized] private int m_RemainingAirJumps;
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public int RemainingAirJumps => this.m_RemainingAirJumps;
        //public int AirJumps => this.m_Character.Motion.AirJumps - this.m_RemainingAirJumps;

        // INITIALIZE METHODS: --------------------------------------------------------------------
        
        internal void OnStartup(Character_2 character)
        {
            this.m_Character = character;
            this.m_Character.EventLand += this.OnLand;
            this.m_Character.EventJump += this.OnJump;
        }
        
        internal void AfterStartup(Character_2 character)
        { }

        internal void OnDispose(Character_2 character)
        {
            this.m_Character = character;
            this.m_Character.EventLand += this.OnLand;
            this.m_Character.EventJump -= this.OnJump;
        }

        internal void OnEnable()
        { }

        internal void OnDisable()
        { }
        
        // PUBLIC METHODS: ------------------------------------------------------------------------

        public void Do()
        {
            if (!this.CanJump()) return;
            //this.m_Character.Motion.Jump();
        }
        
        public void Do(float force)
        {
            if (!this.CanJump()) return;
            //this.m_Character.Motion.Jump(force);
        }
        
        public bool CanJump()
        {
            if (this.m_Character.Busy.AreLegsBusy) return false;
            if (this.m_Character.Driver.IsGrounded) return true;
            return this.m_RemainingAirJumps > 0;
        }
        
        // CALLBACKS: -----------------------------------------------------------------------------

        private void OnLand(float velocity)
        {
            //this.m_RemainingAirJumps = this.m_Character.Motion.AirJumps;
        }
        
        private void OnJump(float force)
        {
            if (this.m_Character.Driver.IsGrounded) return;
            this.m_RemainingAirJumps -= 1;
        }
    }
}