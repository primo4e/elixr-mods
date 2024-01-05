﻿using System;
using System.Collections.Generic;
using System.Text;

// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.EM.Food.Cuisine
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Noodle")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true)]
    public partial class NoodleFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Noodle");
        public override LocString DisplayDescription => Localizer.DoStr("Dough in various shape.");

        public override float Calories => 188;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 25, Fat = 0, Protein = 0, Vitamins = 0 };

        protected override int BaseShelfLife => throw new NotImplementedException();
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class NoodleFoodRecipe : RecipeFamily
    {
        public NoodleFoodRecipe()
        {
            var product = new Recipe(
                "Noodle",
                Localizer.DoStr("Noodle"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FlourItem), 4, typeof(CookingSkill)),
                },
                new CraftingElement<NoodleFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(NoodleFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Noodle"), typeof(NoodleFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
