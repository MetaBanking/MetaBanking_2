namespace Character_2
{
    public interface ICharacterKernel_2
    {
        // ACCESSORS: -----------------------------------------------------------------------------

        IUnitPlayer_2 Player { get; }
        //IUnitMotion Motion { get; }
        //IUnitDriver Driver { get; }
        //IUnitFacing Facing { get; }
        //IUnitAnimim Animim { get; }

        Character_2 Character { get; }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        void OnStartup(Character_2 character);
        void AfterStartup(Character_2 character);
        void OnDispose(Character_2 character);

        void OnEnable();
        void OnDisable();

        void OnUpdate();

        void OnDrawGizmos(Character_2 character);
    }
}