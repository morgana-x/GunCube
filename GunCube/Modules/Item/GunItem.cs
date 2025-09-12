using MCGalaxy.Events.PlayerEvents;
using MCGalaxy;
using System;
using GunCube.Modules.Projectile;

namespace GunCube.Modules.Item
{
    public class GunItem : Item
    {
        public int Ammo = 0;
        public virtual int MaxAmmo => -1;
        public int AmmoType => 0;

        public virtual float ShootCooldown => 0.1f;
        public virtual float ReloadCooldown => 1f;

        public virtual float Spread => 0;

        public DateTime lastFire = DateTime.MinValue;
        public DateTime lastReload = DateTime.MinValue;
        public int GetAmmo(Player p) => Modules.Players.Ammo.GetAmmo(p, AmmoType);
        public void SetAmmo(Player p, int ammo) { Players.Ammo.SetAmmo(p, AmmoType, ammo); }
        public bool HasAmmo(MCGalaxy.Player p) => MaxAmmo == -1 || GetAmmo(p) > 0;

        public virtual Projectile.Projectile CreateProjectile() { return new Bullet(); }

        static System.Random rnd = new System.Random();
        static int dir => rnd.Next(2) == 0 ? 1 : -1;
        public override void OnLeftClick(Player p, MouseAction action, ushort yaw, ushort pitch, byte entityid, ushort bx, ushort by, ushort bz, TargetBlockFace face)
        {
            if (action == MouseAction.Released) return;
            if (!HasAmmo(p)) return;


            if ((DateTime.Now - lastFire).TotalSeconds < ShootCooldown) return;
            if ((DateTime.Now - lastReload).TotalSeconds < ReloadCooldown) return;

            lastFire = DateTime.Now;

            if (MaxAmmo != -1 && GetAmmo(p) > 0) 
                SetAmmo(p, GetAmmo(p) - 1);

            if (Spread != 0)
                Shoot(p, (ushort)(yaw + ((float)dir * (float)rnd.NextDouble() * Spread)), (ushort)(pitch + ((float)dir * (float)rnd.NextDouble() * Spread)));
            else
                Shoot(p, yaw, pitch);
        }

        public virtual void Shoot(MCGalaxy.Player p, ushort yaw, ushort pitch)
        {
            var projectie = CreateProjectile();
            Projectile.Projectile.Throw(p, projectie, yaw, pitch, 6f);
        }

        public virtual void Reload(MCGalaxy.Player p)
        {
            lastReload = DateTime.Now;
            SetAmmo(p, MaxAmmo);
        }
    }
}
