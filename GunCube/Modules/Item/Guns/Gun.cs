using MCGalaxy;

namespace GunCube.Modules.Item.Guns
{
    public class Gun : GunItem
    {
        public override ushort BlockID => (ushort)ItemID.Gun;

        public override BlockDefinition BlockDefinition => new BlockDefinition() { RawID = BlockID, MaxX = 12, MaxY = 12, MaxZ = 12, MinX = 6, MinY = 6, MinZ = 6, BackTex = 50, BottomTex = 50, FrontTex = 50, TopTex = 50, LeftTex = 50, RightTex = 50, FallBack = 79, Name = "Gun", BlockDraw = 1, Shape = 16 };

        public override float ShootCooldown => 0.1f;
        public override float Spread => 1000f;
    }
}
