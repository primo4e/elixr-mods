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
    public partial class RecurveBowRecipe :
        RecipeFamily
    {
        public RecurveBowRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "StringRecurveBow",
                    Localizer.DoStr("String Recurve Bow"),
                    new IngredientElement[]
                    {
               new IngredientElement(typeof(RecurveBowFrameItem), 1, true),
               new IngredientElement(typeof(ModernBowStringItem), 1, true),
                    },
                new CraftingElement<RecurveBowItem>()
                )
            };
            this.LaborInCalories = CreateLaborInCaloriesValue(250); 
            this.CraftMinutes = CreateCraftTimeValue(0.5f);    
            this.Initialize(Localizer.DoStr("String Recurve Bow"), typeof(RecurveBowRecipe));
            CraftingComponent.AddRecipe(typeof(ToolBenchObject), this);
        }
    }

    [Serialized]
    [LocDisplayName("Recurve Bow")]
    [Tier(3)] 
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                    
    public partial class RecurveBowItem : BowItem
    {
        // Static values
        private static IDynamicValue caloriesBurn = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(RecurveBowItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(10, typeof(HuntingSkill), typeof(RecurveBowItem)));
        private static IDynamicValue damage = CreateDamageValue(1.2f, typeof(HuntingSkill), typeof(RecurveBowItem)); 
        private static IDynamicValue exp = new ConstantValue(1);
        private static IDynamicValue tier = new ConstantValue(3);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);


        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A recurve bow that shoots faster and more powerful than a traditional wooden bow. Requires arrows to fire.");    
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override IDynamicValue Damage            => damage; 
        public override Type ExperienceSkill            => typeof(HuntingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 1000f;
        public override Item RepairItem => RandomUtil.CoinToss() ? Get<RecurveBowFrameItem>() : Get<ModernBowStringItem>();
        public override int FullRepairAmount => 1;
    }
}
