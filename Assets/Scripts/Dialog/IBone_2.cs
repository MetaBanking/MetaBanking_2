using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{ 
    [Title("Bone Type")]
    
    public interface IBone_2
    {
        Transform GetTransform(Animator animator);
    }
}