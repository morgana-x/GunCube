using MCGalaxy;

namespace GunCube.Modules.Players
{
    internal class Ammo
    {
        public static void Load()
        {
         
        }

        public static void Unload()
        {
        }

        public static int GetAmmo(Player p, int AmmoType) => p.Extras.GetInt($"ammo_{AmmoType.ToString("X")}");
        public static void SetAmmo(Player p, int AmmoType, int ammo) { p.Extras[$"ammo_{AmmoType.ToString("X")}"] = ammo; }
        public static bool HasAmmo(MCGalaxy.Player p, int AmmoType) => GetAmmo(p, AmmoType) > 0;

     

    }
}
