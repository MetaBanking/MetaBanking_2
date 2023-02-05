using GameCreator.Runtime.Common;
using UnityEngine;

namespace Character_2
{
    public interface IInteractive_2 : ISpatialHash
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        /// <summary>
        /// The scene object that this interface belongs to
        /// </summary>
        GameObject Instance { get; }
        
        /// <summary>
        /// Whether this Interactive object is being interacted. Useful to hide any interaction
        /// tooltips while it is running
        /// </summary>
        bool IsInteracting { get; }
        
        // METHODS: -------------------------------------------------------------------------------
        
        /// <summary>
        /// Executed when a character attempts to interact with this interface
        /// </summary>
        /// <param name="character"></param>
        void Interact(Character_2 character);

        /// <summary>
        /// Executed when the interaction finishes
        /// </summary>
        void Stop();
    }
}