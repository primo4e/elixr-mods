﻿#define EM_Artistry
using Eco.Core.Plugins;
using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.EM.Framework;
using Eco.Gameplay.Players;
using Eco.Shared.Localization;
using Eco.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eco.EM.Artistry
{
    class ArtistryBase : IInitializablePlugin, IModKitPlugin
    {
        public const string version = "2.0.0";
        public const string packName = "Artistry Pack Version:";
        public const string application = "[Elixr Mods]:";

        public string GetStatus()
        {
            return "Loaded and getting creative..";
        }

        public override string ToString()
        {
            return Localizer.DoStr("EM Artistry");
        }

        /// <summary>
        /// Apply the new skills to each person who logs into the server if they do not have it.
        /// This is required to have the UI add the profession correctly also.
        /// </summary>
        public void Initialize(TimedTask timer)
        {
            UserManager.OnUserLoggedIn.Add(u =>
            {
                if (!u.Skillset.HasSkill(typeof(ArtistSkill)))
                    u.Skillset.LearnSkill(typeof(ArtistSkill));
            });
        }
    }
}
