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
    public partial class ModernHammerRecipe :
        RecipeFamily
    {
        public ModernHammerRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ModernHammer",
                    Localizer.DoStr("Modern Hammer"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(ModernHammerHeadItem), 1, true),
               new IngredientElement(typeof(ModernHandleItem), 1, true),
                    },
                new CraftingElement<ModernHammerItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);    
            this.Initialize(Localizer.DoStr("Modern Hammer"), typeof(ModernHammerRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Modern Hammer")]
    [Tier(4)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class ModernHammerItem : HammerItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(ModernHammerItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(5, typeof(SelfImprovementSkill), typeof(ModernHammerItem)));
        private static IDynamicValue tier = new ConstantValue(4);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);


        // Tool overrides

        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 2500f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<ModernHammerHeadItem>() : Get<ModernHandleItem>();
        public override int FullRepairAmount => 1;
    }
}
