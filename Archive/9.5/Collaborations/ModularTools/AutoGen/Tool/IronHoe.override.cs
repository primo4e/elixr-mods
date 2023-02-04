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

    [RepairRequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class IronHoeRecipe :
        RecipeFamily
    {
        public IronHoeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "IronHoe",
                    Localizer.DoStr("Iron Hoe"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(IronHoeHeadItem), 1, true),
               new IngredientElement(typeof(BasicWoodHandleItem), 1, true),
                    },
                new CraftingElement<IronHoeItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.Initialize(Localizer.DoStr("Iron Hoe"), typeof(IronHoeRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Iron Hoe")]
    [Tier(2)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class IronHoeItem : HoeItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(IronHoeItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(17, typeof(FarmingSkill), typeof(IronHoeItem)));
        private static IDynamicValue exp = new ConstantValue(0.1f);
        private static IDynamicValue tier = new ConstantValue(2);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);


        // Tool overrides

        public override IDynamicValue CaloriesBurn => caloriesBurn;
        public override Type ExperienceSkill => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate => exp;
        public override IDynamicValue Tier => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate => DurabilityMax / 300f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<IronHoeHeadItem>() : Get<BasicWoodHandleItem>();
        public override int FullRepairAmount => 1;
    }
}