using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    [Title("Driver")]
    
    public interface IUnitDriver_2 : IUnitCommon_2
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        Vector3 WorldMoveDirection { get; }
        Vector3 LocalMoveDirection { get; }
        
        float SkinWidth { get; }
        bool IsGrounded { get; }
        Vector3 FloorNormal { get; }
        
        bool Collision { get; set; }

        // POSITION MODIFIERS: --------------------------------------------------------------------

        void SetPosition(Vector3 position);
        void SetRotation(Quaternion rotation);
        void SetScale(Vector3 scale);

        void AddPosition(Vector3 amount);
        void AddRotation(Quaternion amount);
        void AddScale(Vector3 amount);
    }
}