using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character_2
{
    [Title("Player")]
    
    public interface IUnitPlayer_2 : IUnitCommon_2
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        bool IsControllable { get; set; }

        Vector3 InputDirection { get; }
    }
}