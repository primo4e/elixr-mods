﻿using System;
using System.Collections.Generic;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Games.BoardGames
{
    [Serialized, LocDisplayName("Patrol Boat"), MaxStackSize(100)]
    public partial class PatrolBoatItem : WorldObjectItem<PatrolBoatObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("The Patrol Board for playing Battleship");
    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class PatrolBoatObject : BattleshipBase, IRepresentsItem
    {
        public override LocString DisplayName => Localizer.DoStr("Patrol Boat");

        public Type RepresentedItemType => typeof(PatrolBoatItem);

        static PatrolBoatObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int x = 0; x <= 0; x++)
                for (int y = 0; y <= 0; y++)
                    for (int z = -1; z <= 0; z++)
                        BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(x, y, z), typeof(WorldObjectBlock)));

            AddOccupancy<PatrolBoatObject>(BlockOccupancyList);
        }


    }

    //Todo Add Recipe
    public partial class PatrolBoatRecipe : RecipeFamily
    {

    }
}