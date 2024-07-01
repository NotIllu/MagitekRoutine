﻿using ff14bot;
using Magitek.Extensions;
using Magitek.Models.Pictomancer;
using Magitek.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magitek.Logic.Pictomancer
{
    internal static class AOE
    {
        public static async Task<bool> HolyinWhite()
        {
            if (PictomancerSettings.Instance.UseAoe == false)
                return false;

            if (!Spells.HolyinWhite.IsKnownAndReady())
                return false;

            if (!Spells.HolyinWhite.CanCast(Core.Me.CurrentTarget))
                return false;

            if (Core.Me.CurrentTarget.EnemiesNearby(5).Count() < PictomancerSettings.Instance.AoeEnemies)
                return false;

            return await Spells.HolyinWhite.Cast(Core.Me.CurrentTarget);
        }

        public static async Task<bool> Paint()
        {
            if (PictomancerSettings.Instance.UseAoe == false)
                return false;

            if (Core.Me.CurrentTarget.EnemiesNearby(5).Count() < PictomancerSettings.Instance.AoeEnemies)
                return false;

            if (Core.Me.HasAura(Auras.SubtractivePalette))
            {
                if (Core.Me.HasAura(Auras.Aetherhues2))
                    if (Spells.ThunderIIinMagenta.IsKnownAndReady())
                        return await Spells.ThunderIIinMagenta.Cast(Core.Me.CurrentTarget);
                if (Core.Me.HasAura(Auras.Aetherhues))
                    if (Spells.StoneIIinYellow.IsKnownAndReady())
                        return await Spells.StoneIIinYellow.Cast(Core.Me.CurrentTarget);
                if (Spells.BlizzardIIinCyan.IsKnownAndReady())
                    return await Spells.BlizzardIIinCyan.Cast(Core.Me.CurrentTarget);
            }
            else
            {
                if (Core.Me.HasAura(Auras.Aetherhues2))
                    if (Spells.WaterIIinBlue.IsKnownAndReady())
                        return await Spells.WaterIIinBlue.Cast(Core.Me.CurrentTarget);
                if (Core.Me.HasAura(Auras.Aetherhues))
                    if (Spells.AeroIIinGreen.IsKnownAndReady())
                        return await Spells.AeroIIinGreen.Cast(Core.Me.CurrentTarget);
                if (Spells.FireIIinRed.IsKnownAndReady())
                    return await Spells.FireIIinRed.Cast(Core.Me.CurrentTarget);
            }

            return false;
        }
    }
}