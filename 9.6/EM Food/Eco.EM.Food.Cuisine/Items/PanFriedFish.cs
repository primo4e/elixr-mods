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
    [LocDisplayName("Pan Fried Fish")]
    [Weight(300)]
    //[Tag("BakedVegetable", 1)]
    //[Tag("BakedFood", 1)]
    [Ecopedia("Food", "Baking", createAsSubPage: true)]
    public partial class PanFriedFishFoodItem : FoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Pan Fried Fish");
        public override LocString DisplayDescription => Localizer.DoStr("Fishes fried on a pan.");

        public override float Calories => 636;
        public override Nutrients Nutrition => new Nutrients() { Carbs = 0, Fat = 3.6f, Protein = 6.6f, Vitamins = 1.2f };

        protected override int BaseShelfLife => throw new NotImplementedException();
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class PanFriedFishFoodRecipe : RecipeFamily
    {
        public PanFriedFishFoodRecipe()
        {
            var product = new Recipe(
                "Pan Fried Fish",
                Localizer.DoStr("Pan Fried Fish"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(RawFishItem), 3, typeof(CookingSkill)),
                    new IngredientElement(typeof(OilItem), 1, typeof(CookingSkill)),
                },
                new CraftingElement<PanFriedFishFoodItem>(1)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PanFriedFishFoodRecipe), 1, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Pan Fried Fish"), typeof(PanFriedFishFoodRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
