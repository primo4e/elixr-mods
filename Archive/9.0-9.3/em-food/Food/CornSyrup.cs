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
    [Weight(200)]
    [MaxStackSize(100)]
    [LocDisplayName("Corn Syrup")]
    [Ecopedia("Food", "Ingredients", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CornSyrupItem :
        FoodItem            
    {
        public override LocString DisplayDescription            => Localizer.DoStr("Corn syrup, also known as glucose syrup to confectioners");

        private static Nutrients nutrition = new Nutrients()    { Carbs = 4, Fat = 4, Protein = 5, Vitamins = 2};
        public override float Calories                          => 55;
        public override Nutrients Nutrition                     => nutrition;
    }

	[RequiresSkill(typeof(ZymologySkill), 3)]   
    public partial class CornSyrupRecipe : RecipeFamily
    {
        public CornSyrupRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Corn Syrup",
                    Localizer.DoStr("Corn Syrup"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CornItem), 4, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                        new IngredientElement(typeof(MaltoseItem), 2, typeof(ZymologySkill), typeof(ZymologyLavishResourcesTalent)),
                    },
                    new CraftingElement<CornSyrupItem>(2)
                    )
            };
            this.ExperienceOnCraft = 1;  
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(ZymologySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CornSyrupRecipe), 8, typeof(ZymologySkill), typeof(ZymologyParallelSpeedTalent), typeof(ZymologyFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Corn Syrup"), typeof(CornSyrupRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FermentingBarrelObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}