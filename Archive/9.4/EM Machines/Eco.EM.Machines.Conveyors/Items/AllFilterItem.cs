﻿using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using System.Collections.Generic;

namespace Eco.EM.Machines.Conveyors
{
    [Serialized]
    [Weight(50)]
    [LocDisplayName("All Items Filter")]
    [MaxStackSize(100)]
    [FilterModule]
    public partial class AllFilterItem : FilterModuleItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("Makes an inserter move all items from the extraction inventory.");

        private List<Item> filterList;
        public override List<Item> FilterList => filterList;

        public override void Init()
        {
            List<Item> returnList = new();
            foreach (var i in AllItems)
            {
                returnList.Add(i);
            }
            filterList = returnList;
        }
    }

    [RequiresSkill(typeof(ElectronicsSkill), 1)]
    public partial class AllFilterRecipe : RecipeFamily
    {
        public AllFilterRecipe()
        {
            var product = new Recipe(
                    "All Filter",
                    Localizer.DoStr("All Filter"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CopperWiringItem), 2 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                        new IngredientElement(typeof(GoldFlakesItem), 1 ,typeof(ElectronicsSkill), typeof(ElectronicsLavishResourcesTalent)),
                    },

                    new CraftingElement<AllFilterItem>(1f)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, typeof(ElectronicsSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AllFilterRecipe), 1f, typeof(ElectronicsSkill), typeof(ElectronicsParallelSpeedTalent), typeof(ElectronicsFocusedSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("All Filter"), typeof(AllFilterRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ElectronicsAssemblyObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
