using System;
using GameCreator.Runtime.Common;

namespace Character_2
{
    [Title("3D Character Controller")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Green)]
    
    [Category("3D Character Controller")]
    [Description("Configures the default 3D character controller")]

    [Serializable]
    public class KernelPreset3DController : IKernelPreset_2
    {
        public IUnitPlayer_2 MakePlayer => new UnitPlayerDirectional_2();
        public IUnitMotion_2 MakeMotion => new UnitMotionController_2();
        //public IUnitDriver_2 MakeDriver => new UnitDriverController_2();
        //public IUnitFacing MakeFacing => new UnitFacingPivot();
        //public IUnitAnimim_2 MakeAnimim => new UnitAnimimKinematic_2();
    }
}