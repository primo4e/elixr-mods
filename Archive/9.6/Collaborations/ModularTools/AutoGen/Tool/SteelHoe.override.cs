﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;

    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 2)] 
    public partial class SteelHoeRecipe :
        RecipeFamily
    {
        public SteelHoeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "SteelHoe",
                    Localizer.DoStr("Steel Hoe"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(SteelHoeHeadItem), 1, true),
               new IngredientElement(typeof(ModernWoodHandleItem), 1, true),
                    },
                new CraftingElement<SteelHoeItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);    
            this.Initialize(Localizer.DoStr("Steel Hoe"), typeof(SteelHoeRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Steel Hoe")]
    [Tier(3)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]                    
    public partial class SteelHoeItem : HoeItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SteelHoeItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(15, typeof(FarmingSkill), typeof(SteelHoeItem)));
        private static IDynamicValue exp = new ConstantValue(0.1f);
        private static IDynamicValue tier = new ConstantValue(3);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);

        private static Vector2i[] areaBlocks = new Vector2i[]
        {
        new Vector2i(0, 1), 
        };

        // Tool overrides

        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 750f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<SteelHoeHeadItem>() : Get<ModernWoodHandleItem>();
        public override int FullRepairAmount => 1;
        public override Vector2i[] AreaBlocks           => areaBlocks;
    }
}
