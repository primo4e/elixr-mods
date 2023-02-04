﻿using System;
using System.Collections.Generic;
using Eco.Core.Items;
using Eco.EM.Framework.Resolvers;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Shared.Math;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Mods.TechTree;
using Eco.Gameplay.Skills;

namespace Eco.EM.Machines.Vehicles
{
    [Serialized]
    [LocDisplayName("Super Car")]
    [Weight(25000)]
    [AirPollution(0.5f)]
    public partial class SuperCarItem : WorldObjectItem<SuperCarObject>
    {
        public override LocString DisplayDescription => Localizer.DoStr("Modern Super Car");
    }

    [RequiresSkill(typeof(IndustrySkill), 4)]
    public class SuperCarRecipe : RecipeFamily, IConfigurableRecipe
    {
        static RecipeDefaultModel Defaults => new()
        {
            ModelType = typeof(SuperCarRecipe).Name,
            Assembly = typeof(SuperCarRecipe).AssemblyQualifiedName,
            HiddenName = "Super Car",
            LocalizableName = Localizer.DoStr("Super Car"),
            IngredientList = new()
            {
                new EMIngredient("GearboxItem", false, 6),
                new EMIngredient("SteelPlateItem", false, 20),
                new EMIngredient("NylonFabricItem", false, 10),
                new EMIngredient("AdvancedCombustionEngineItem", false, 1, true),
                new EMIngredient("RubberWheelItem", false, 4, true),
                new EMIngredient("RadiatorItem", false, 1, true),
                new EMIngredient("SteelAxleItem", false, 1, true),
                
            },
            ProductList = new()
            {
                new EMCraftable("SuperCarItem"),
            },
            BaseExperienceOnCraft = 1f,
            BaseLabor = 2500,
            LaborIsStatic = false,
            BaseCraftTime = 10,
            CraftTimeIsStatic = false,
            CraftingStation = "RoboticAssemblyLineItem",
            RequiredSkillType = typeof(IndustrySkill),
            RequiredSkillLevel = 4,
            SpeedImprovementTalents = new Type[] { typeof(IndustryFocusedSpeedTalent), typeof(IndustryParallelSpeedTalent) }
        };

        static SuperCarRecipe() { EMRecipeResolver.AddDefaults(Defaults); }

        public SuperCarRecipe()
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
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(ModularStockpileComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class SuperCarObject : PhysicsWorldObject, IRepresentsItem, IConfigurableVehicle
    {
        public override LocString DisplayName => Localizer.DoStr("SuperCar");
        public Type RepresentedItemType => typeof(SuperCarItem);

        private readonly static VehicleModel defaults = new(
            typeof(SuperCarObject),
            displayName: "Super Car",
            fuelTagList: fuelTagList,
            fuelSlots: 2,
            fuelConsumption: 25,
            airPollution: 0.5f,
            maxSpeed: 30,
            efficencyMultiplier: 2,
            storageSlots: 0,
            maxWeight: 0,
            seats: 1
        );

        static SuperCarObject()
        {
            WorldObject.AddOccupancy<SuperCarObject>(new List<BlockOccupancy>(0));
            EMVehicleResolver.AddDefaults(defaults);
        }

        private static readonly string[] fuelTagList = new string[]
        {
            "Liquid Fuel"
        };

        private SuperCarObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<PublicStorageComponent>().Initialize(EMVehicleResolver.Obj.ResolveStorageSlots(this), EMVehicleResolver.Obj.ResolveMaxWeight(this));
            this.GetComponent<FuelSupplyComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelSlots(this), fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(EMVehicleResolver.Obj.ResolveFuelConsumption(this));
            this.GetComponent<AirPollutionComponent>().Initialize(EMVehicleResolver.Obj.ResolveAirPollution(this));
            this.GetComponent<VehicleComponent>().Initialize(EMVehicleResolver.Obj.ResolveMaxSpeed(this), EMVehicleResolver.Obj.ResolveEfficiencyMultiplier(this), EMVehicleResolver.Obj.ResolveSeats(this));
            this.GetComponent<StockpileComponent>().Initialize(new Vector3i(2, 2, 3));
        }
    }
}
