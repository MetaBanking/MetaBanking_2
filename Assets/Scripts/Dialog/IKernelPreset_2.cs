using GameCreator.Runtime.Common;

namespace Character_2
{
    [Title("Preset")]
    public interface IKernelPreset_2
    {
        IUnitPlayer_2 MakePlayer { get; }
        IUnitMotion_2 MakeMotion { get; }
        //IUnitDriver_2 MakeDriver { get; }
        // IUnitFacing MakeFacing { get; }
        //IUnitAnimim_2 MakeAnimim { get; }
    }
}