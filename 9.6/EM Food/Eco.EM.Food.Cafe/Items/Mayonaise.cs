﻿using System;
using System.Collections.Generic;
using System.Text;

// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.EM.Food.Cafe
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.EM.Framework.Resolvers;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;

    [Serialized]
    [LocDisplayName("Mayonaise")]
    [Weight(300)]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true)]
    public partial class MayonaiseItem : FoodItem, IConfigurableFoodItem
    {
        public override LocString DisplayNamePlural => Localizer.DoStr("Mayonaise");
        public override LocString DisplayDescription => Localizer.DoStr("Blended egg and oil.");
        private static readonly FoodItemModel defaults = new(typeof(MayonaiseItem), "Mayonaise", calories: 70, carbs: 1, fat: 7, protein: 1, shelflife:12, vitamins: 0);
        protected override float BaseShelfLife => EMFoodItemResolver.Obj.ResolveShelfLife(this);
        public override float Calories => EMFoodItemResolver.Obj.ResolveCalories(this);
        public override Nutrients Nutrition => EMFoodItemResolver.Obj.ResolveNutrients(this);
        static MayonaiseItem() => EMFoodItemResolver.AddDefaults(defaults);
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class MayonaiseRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(MayonaiseRecipe).Name,
            Assembly = typeof(MayonaiseRecipe).AssemblyQualifiedName,
            HiddenName = "Mayonaise",
            LocalizableName = Localizer.DoStr("Mayonaise"),
            IngredientList = new()
            {
                new EMIngredient("OilItem", false, 3),
                new EMIngredient("Egg", true, 3),
            },
            ProductList = new()
            {
                new EMCraftable("MayonaiseItem", 6),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 0.5f,
            CraftTimeIsStatic = false,
            CraftingStation = "BlenderItem",
            RequiredSkillType = typeof(CookingSkill),
            RequiredSkillLevel = 1,
        };

        static MayonaiseRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public MayonaiseRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }
}
