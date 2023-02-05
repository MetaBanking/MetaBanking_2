using UnityEngine;

namespace Character_2
{
    internal interface IProp_2
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        Transform Bone { get; }
        GameObject Instance { get; }
        
        // METHODS: -------------------------------------------------------------------------------

        void Create(Animator animator);
        void Destroy();
        void Drop();
    }
}