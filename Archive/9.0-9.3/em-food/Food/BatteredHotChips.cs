using System.Collections.Generic;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;

namespace Eco.EM.Food
{
    [Serialized]
    [Weight(500)]
    [MaxStackSize(100)]
    [LocDisplayName("Battered Hot Chips")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BatteredHotChipsItem :
        FoodItem            
    {
        public override LocString DisplayDescription                     => Localizer.DoStr("Battered Hot Chips");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 10, Fat = 12, Protein = 10, Vitamins = 10};
        public override float Calories                          => 1100;
        public override Nutrients Nutrition                     => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 3)]    
    public partial class BatteredHotChipsRecipe : RecipeFamily
    {
        public BatteredHotChipsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Battered Hot Chips",
                    Localizer.DoStr("Battered Hot Chips"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BatterItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(StraightCutChipsItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(UrchinOilItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<BatteredHotChipsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BatteredHotChipsRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Battered Hot Chips"), typeof(BatteredHotChipsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KitchenObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(CookingSkill), 3)]
    public partial class AltBatteredHotChipsRecipe : RecipeFamily
    {
        public AltBatteredHotChipsRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Battered Hot Chips",
                    Localizer.DoStr("Battered Hot Chips"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(BatterItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(StraightCutChipsItem), 4, typeof(CookingSkill), typeof(CookingLavishResourcesTalent)),
                        new IngredientElement(typeof(UrchinOilItem), 2, typeof(CookingSkill), typeof(CookingLavishResourcesTalent))
                    },
                    new CraftingElement<BatteredHotChipsItem>(4)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AltBatteredHotChipsRecipe), 8, typeof(CookingSkill), typeof(CookingParallelSpeedTalent), typeof(CookingFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Battered Hot Chips"), typeof(AltBatteredHotChipsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}