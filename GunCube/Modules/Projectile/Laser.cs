using MCGalaxy;
using MCGalaxy.Blocks;
using MCGalaxy.Maths;
using GunCube.Modules.Players;
using GunCube.Modules.World;
using static GunCube.Events.PlayerEvents;
namespace GunCube.Modules.Projectile
{
    public class Laser : Projectile
    {

        public Laser(Level level, Player thrower, Vec3F32 position, Vec3S32 velocity) : base(level, thrower, position, velocity)
        {

        }

        public Laser()
        {

        }
        public override float Gravity => 0f;
        public override float Drag => 1f;

        public override bool Tick(float curtime)
        {
            for (int i = 0; i < 5; i++)
            {
                Effect.EmitEffect(Level, Effect.Effects.Laser_Trail_Red, Pos + (Vel*i*0.1f));
                Effect.EmitEffect(Level, Effect.Effects.Laser_Trail_Red2, Pos + (Vel*i*0.1f));
            }
            //    Effect.EmitEffect(Level, Effect.Effects.Snowball_Ball, Pos);
            return base.Tick(curtime);
        }

        public override void OnDestroy()
        {
        //    Effect.EmitEffect(Level, Effect.Effects.Laser_Hit_Red, Pos);
            base.OnDestroy();
        }

        public override void OnCollide(ushort block, Player pl)
        {
            if (pl != null)
            {
                bool cancel = false;

                if (!cancel)
                {
                    pl.Send(MCGalaxy.Network.Packet.VelocityControl(Vel.X * 0.05f, 0.25f, Vel.Z *0.05f, 0, 0, 0));
                    Health.Damage(pl, 1, DamageData.DamageType.Snowball, Thrower);
                }

            }
            Sound.EmitSound(Level, 0, (ushort)SoundType.Snow, BlockPos.X, BlockPos.Y, BlockPos.Z, 100, 100);
            Effect.EmitEffect(Level, Effect.Effects.Laser_Hit_Red, Pos + new Vec3F32(0, 1, 0));
            base.OnCollide(block, pl);
        }
    }
}
