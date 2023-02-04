using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Shared.Serialization;
using Eco.Shared.Localization;
using Eco.Mods.TechTree;
using Eco.Shared.Math;
using Eco.EM.Framework.Resolvers;
using Eco.Core.Items;
using System;

namespace Eco.EM.Housing.Doors
{
    [RequiresSkill(typeof(LoggingSkill), 0)]
    public partial class ElegantDoorRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(ElegantDoorRecipe).Name,
            Assembly = typeof(ElegantDoorRecipe).AssemblyQualifiedName,
            HiddenName = "Elegant Door",
            LocalizableName = Localizer.DoStr("Elegant Door"),
            IngredientList = new()
            {
                new EMIngredient("Wood", true, 8),
            },
            ProductList = new()
            {
                new EMCraftable("ElegantDoorItem"),
            },
            BaseExperienceOnCraft = 1,
            BaseLabor = 150,
            LaborIsStatic = false,
            BaseCraftTime = 1,
            CraftTimeIsStatic = false,
            CraftingStation = "CarpentryTableItem",
            RequiredSkillType = typeof(LoggingSkill),
            RequiredSkillLevel = 0,
        };

        static ElegantDoorRecipe()
        {
            EMRecipeResolver.AddDefaults(Defaults);
        }

        public ElegantDoorRecipe()
        {
            this.Recipes = EMRecipeResolver.Obj.ResolveRecipe(this);
            this.LaborInCalories = EMRecipeResolver.Obj.ResolveLabor(this);
            this.CraftMinutes = EMRecipeResolver.Obj.ResolveCraftMinutes(this);
            this.ExperienceOnCraft = EMRecipeResolver.Obj.ResolveExperience(this);
            this.Initialize(Defaults.LocalizableName, GetType());
            CraftingComponent.AddRecipe(EMRecipeResolver.Obj.ResolveStation(this), this);
        }
    }

    [Serialized]
    [LocDisplayName("Elegant Door")]
    [Tier(1)]
    [Weight(600)]
    [MaxStackSize(10)]
    [Ecopedia("Modded Objects", "Modded Doors", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public class ElegantDoorItem : WorldObjectItem<ElegantDoorObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("An Elegant Style Door.");

    }

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class ElegantDoorObject : DoorObject
    {
        public override LocString DisplayName => Localizer.DoStr("Elegant Door");
        public override Type RepresentedItemType => typeof(ElegantDoorItem);
        public override bool HasTier => true;
        public override int Tier => 1;
        protected override void Initialize() { }

        public override void Destroy() => base.Destroy();

        static ElegantDoorObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>()
            {
                new BlockOccupancy(new Vector3i(0,0,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0,1,0), typeof(BuildingWorldObjectBlock), new Quaternion(0f, 0f, 0f, 1f), ""),
                new BlockOccupancy(new Vector3i(0,0,1)),
                new BlockOccupancy(new Vector3i(0,0,-1)),
                new BlockOccupancy(new Vector3i(0,1,1)),
                new BlockOccupancy(new Vector3i(0,1,-1)),
            };
            AddOccupancy<ElegantDoorObject>(BlockOccupancyList);
        }
    }
}