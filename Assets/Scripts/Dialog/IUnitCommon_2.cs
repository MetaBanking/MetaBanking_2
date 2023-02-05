using System;

namespace Character_2
{
    public interface IUnitCommon_2
    {
        void OnStartup(Character_2 character);
        void AfterStartup(Character_2 character);
        void OnDispose(Character_2 character);

        void OnEnable();
        void OnDisable();

        void OnUpdate();
        void OnFixedUpdate();

        void OnDrawGizmos(Character_2 character);
        
        Type ForcePlayer { get; }
        //Type ForceMotion { get; }
        //Type ForceDriver { get; }
        //Type ForceFacing { get; }
        //Type ForceAnimim { get; }
    }
}