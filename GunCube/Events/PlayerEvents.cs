using MCGalaxy.Events;
using MCGalaxy;
using System;
using GunCube.Modules.Players;
using GunCube.Modules.Item;
using GunCube.Modules.Projectile;
namespace GunCube.Events
{
    public class PlayerEvents
    {
        public delegate void PlayerUsingItemLeftClick(Player pl, Item item, ref bool cancel);

        public sealed class PlayerUsingItemLeftClickEvent : IEvent<PlayerUsingItemLeftClick>
        {
            public static void Call(Player p, Item item, ref bool cancel)
            {
                IEvent<PlayerUsingItemLeftClick>[] items = handlers.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    try { items[i].method(p, item, ref cancel); }
                    catch (Exception ex) { LogHandlerException(ex, items[i]); }
                }
            }
        }

        public sealed class PlayerUsingItemRightClickEvent : IEvent<PlayerUsingItemLeftClick>
        {
            public static void Call(Player p, Item item, ref bool cancel)
            {
                IEvent<PlayerUsingItemLeftClick>[] items = handlers.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    try { items[i].method(p, item, ref cancel); }
                    catch (Exception ex) { LogHandlerException(ex, items[i]); }
                }
            }
        }


       

        public delegate void PlayerHitByProjectile(Player pl, Projectile projectile, ref bool cancel);
        public sealed class PlayerHitBySnowballEvent : IEvent<PlayerHitByProjectile>
        {
            public static void Call(Player p, Projectile projectile, ref bool cancel)
            {
                IEvent<PlayerHitByProjectile>[] items = handlers.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    try { items[i].method(p, projectile, ref cancel); }
                    catch (Exception ex) { LogHandlerException(ex, items[i]); }
                }
            }
        }

        public delegate void PlayerDamaging(Player pl, ref DamageData damagedata);

        public sealed class PlayerDamagingEvent : IEvent<PlayerDamaging>
        {
            public static void Call(Player p, ref DamageData damagedata)
            {
                IEvent<PlayerDamaging>[] items = handlers.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    try { items[i].method(p, ref damagedata); }
                    catch (Exception ex) { LogHandlerException(ex, items[i]); }
                }
            }
        }


        public delegate void PlayerKilled(Player player, ref DamageData damagedata);

        public sealed class PlayerKilledEvent : IEvent<PlayerKilled>
        {
            public static void Call(Player p, ref DamageData damagedata)
            {
                IEvent<PlayerKilled>[] items = handlers.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    try { items[i].method(p, ref damagedata); }
                    catch (Exception ex) { LogHandlerException(ex, items[i]); }
                }
            }
        }

      
    }
}
