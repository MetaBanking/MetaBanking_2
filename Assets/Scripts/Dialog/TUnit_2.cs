using System;
using UnityEngine;

namespace Character_2
{
    [Serializable]
    public abstract class TUnit_2
    {
        public Character_2 Character { get; set; }

        public Transform Transform => this.Character != null ? this.Character.transform : null;

        public virtual Type ForcePlayer => null;
        //public virtual Type ForceMotion => null;
        //public virtual Type ForceDriver => null;
        //public virtual Type ForceFacing => null;
        //public virtual Type ForceAnimim => null;
    }
}