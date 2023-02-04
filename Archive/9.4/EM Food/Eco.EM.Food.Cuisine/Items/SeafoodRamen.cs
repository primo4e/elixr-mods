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
    [LocDisplayName("Seafood Ramen")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SeafoodRamenFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Seafood Ramen");
        public override LocString DisplayDescription => Localizer.DoStr("Noodle serve with seafood broth.");

        public override float Calories => 360;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 50f, Fat = 3, Protein = 5f, Vitamins = 0 };
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class SeafoodRamenFoodRecipe : RecipeFamily
    {
        public SeafoodRamenFoodRecipe()
        {
            var product = new Recipe(
                "Seafood Ramen",
                Localizer.DoStr("Seafood Ramen"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(NoodleFoodItem), 1, typeof(CookingSkill)),
                    new IngredientElement(typeof(SeafoodStockFoodItem), 1, typeof(CookingSkill)),
                },
                new CraftingElement<SeafoodRamenFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SeafoodRamenFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Seafood Ramen"), typeof(SeafoodRamenFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
