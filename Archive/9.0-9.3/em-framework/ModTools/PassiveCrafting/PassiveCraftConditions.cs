﻿using Eco.EM.Framework.Utils;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Plants;
using System;
using System.Collections.Generic;
using System.Linq;

// This mod is created by Elixr Mods for Eco under the SLG TOS. 
// Please feel free to join our community Discord which aims to brings together modders of Eco to share knowledge, 
// collaborate on projects and improve the overall experience for Eco modders.
// https://discord.gg/69UQPD2HBR

namespace Eco.EM.ModkitTools
{
    // Interface to group conditions that modders may wish to create to provide fine tuning of passive craft
    public interface IPassiveCraftCondition
    {
        string FailString { get; } // the string returned should this condition fail, for use in a status message
        bool AllowCraft(); // The condition for crafting to proceed
        void OnCraft(); // Call back for post-effects if craft is successful
    }

    // passive craft requires specific ingredients to be available.
    // This condition will check if world object links to inventories or contains its own internal storage and will then look to see if the ingredients are available.
    public class IngredientCraftCondition : IPassiveCraftCondition
    {
        private PassiveCraftingComponent component;
        public List<(Item, float)> Inputs = new List<(Item, float)>();

        private string failString;
        public string FailString => failString;

        public IngredientCraftCondition(PassiveCraftingComponent component, List<(Item, float)> ings)
        {
            this.component = component;
            Inputs = ings;
            component.OutputCrafted += OnCraft;
        }

        public bool AllowCraft()
        {
            bool allowCraft = true;
            failString = "Ingredient prerequisite failure:\n";

            if (component.Parent.HasComponent<LinkComponent>())
            {
                var inventories = component.Parent.GetComponent<LinkComponent>().GetSortedLinkedInventories(component.Parent.Owners);

                foreach (var e in Inputs)
                {
                    var items = inventories.TotalNumberOfItems(e.Item1);
                    if (items < (int)Math.Ceiling(e.Item2))
                    {
                        if (allowCraft) allowCraft = false;
                        failString += $"    {(int)Math.Ceiling(e.Item2)} {((int)Math.Ceiling(e.Item2) == 1 ? e.Item1.DisplayName + " is" : e.Item1.DisplayNamePlural + " are")} required and {items} {(items == 1 ? "is" : "are")} available in storage.\n";
                    }
                }
            }
            else
            {
                allowCraft = false;
            }

            return allowCraft;
        }

        // This will never fire if link component does not exist
        public void OnCraft()
        {
            var inventories = component.Parent.GetComponent<LinkComponent>().GetSortedLinkedInventories(component.Parent.Owners);
            foreach (var e in Inputs) { inventories.RemoveItems(e.Item1.GetType(), (int)Math.Ceiling(e.Item2)); }
        }
    }

    public class PlantAreaCraftCondition : IPassiveCraftCondition
    {
        int radius;
        int requiredNumber;
        List<Type> plantTypes;
        WorldObject parent;
        public string FailString => $"There are not enough plants in the active area ({radius} blocks). You require at least {requiredNumber}.";

        public PlantAreaCraftCondition(WorldObject parent, int checkRadius, int requiredNumber, Type[] plantTypes = null)
        {
            this.radius = checkRadius;
            this.requiredNumber = requiredNumber;
            this.plantTypes = plantTypes.ToList();
            this.parent = parent;
        }

        private int GetPlantsInArea()
        {
            int count = 0;
            var position = this.parent.Position3i;

            var blocks = WorldUtils.GetTopBlocksInRadius(position, radius);

            foreach (var block in blocks)
            {
                if (plantTypes != null) { if (plantTypes.Contains(block.GetType())) count++; }
                else { if (block is PlantBlock) count++; }
            }

            return count;
        }

        public bool AllowCraft() => GetPlantsInArea() >= requiredNumber;

        public void OnCraft() { }
    }

    public class RequiredObjectInAreaCraftCondition : IPassiveCraftCondition
    {
        private WorldObject parent;
        private Type requiredObjectType;
        private int radius;
        private int requiredNumber;

        public string FailString => $"There are not enough {RequiredObjectName()} in the active area ({radius} blocks). You require at least {requiredNumber}.";

        public RequiredObjectInAreaCraftCondition(WorldObject parent, int checkRadius, int requiredNumber, Type worldObjectType)
        {
            this.parent = parent;
            this.radius = checkRadius;
            this.requiredNumber = requiredNumber;
            this.requiredObjectType = worldObjectType;
        }

        private string RequiredObjectName() => WorldObjectItem.GetCreatingItemTemplateFromType(requiredObjectType).DisplayNamePlural;

        public bool AllowCraft() => GetObjectOfTypeInArea() >= requiredNumber;

        private int GetObjectOfTypeInArea() => WorldUtils.GetSurfaceObjectsInRadius(parent.Position3i, radius).Where(obj => obj.GetType() == requiredObjectType).Count();

        public void OnCraft() { }
    }

    public class SaturatedObjectInAreaCraftCondition : IPassiveCraftCondition
    {
        private WorldObject parent;
        private Type requiredObjectType;
        private int radius;
        private int maxTotal;

        public string FailString => $"There are too many {RequiredObjectName()} in the active area ({radius} blocks). You require no more than {maxTotal}.";

        public SaturatedObjectInAreaCraftCondition(WorldObject parent, int checkRadius, int requiredNumber, Type worldObjectType)
        {
            this.parent = parent;
            this.radius = checkRadius;
            this.maxTotal = requiredNumber;
            this.requiredObjectType = worldObjectType;
        }

        private string RequiredObjectName() => WorldObjectItem.GetCreatingItemTemplateFromType(requiredObjectType).DisplayNamePlural;

        public bool AllowCraft() => GetObjectOfTypeInArea() <= maxTotal;

        private int GetObjectOfTypeInArea() => WorldUtils.GetSurfaceObjectsInRadius(parent.Position3i, radius).Where(obj => obj.GetType() == requiredObjectType.GetType()).Count();

        public void OnCraft() { }
    }
}