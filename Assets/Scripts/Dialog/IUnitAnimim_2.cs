using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    [Title("Animation")]
    
    public interface IUnitAnimim_2 : IUnitCommon_2
    {
        /**
         * IMPORTANT NOTE: It is required that the class implementing this interface has a
         * serializable field called 'm_Animator' that is used to know and change the reference
         * of the model in class ModelTool::ChangeModelEditor() 
        **/
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        Transform Mannequin { get; set; }
        
        Animator  Animator { get; set; }
        //BoneRack_2 BoneRack { get; set; }
        //Reaction_2 Reaction { get; set; }
        
        float SmoothTime  { get; set; }
        float ModelOffset { get; set; }
        
        Vector3 RootMotionDeltaPosition { get; }
        Quaternion RootMotionDeltaRotation { get; }

        float HeartRate { get; set; }
        float Exertion  { get; set; }
        float Twitching { get; set; }

        // EVENTS: --------------------------------------------------------------------------------
        
        event Action<int> EventOnAnimatorIK;
        
        // METHODS: -------------------------------------------------------------------------------

        void ResetModelPosition();
    }
}