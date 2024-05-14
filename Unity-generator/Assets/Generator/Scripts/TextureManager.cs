using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMaterialManager", menuName = "MaterialManager")]
public class MaterialManager : ScriptableObject
{
    [System.Serializable]
    public struct MaterialCategoryData
    {
        public MaterialCategory category;
        public List<Material> materials;
    }

    // List of categories and materials
    public List<MaterialCategoryData> materialCategories = new List<MaterialCategoryData>();

    // Add material to category
    public void AddMaterialToCategory(MaterialCategory category, Material material)
    {
        var categoryIndex = materialCategories.FindIndex(c => c.category == category);
        if (categoryIndex != -1)
        {
            materialCategories[categoryIndex].materials.Add(material);
        }
        else
        {
            MaterialCategoryData newCategory = new MaterialCategoryData { category = category, materials = new List<Material> { material } };
            materialCategories.Add(newCategory);
        }
    }

    // Get random material from category
    public Material GetRandomMaterialFromCategory(MaterialCategory category)
    {
        var categoryIndex = materialCategories.FindIndex(c => c.category == category);
        if (categoryIndex != -1 && materialCategories[categoryIndex].materials.Count > 0)
        {
            int randomIndex = Random.Range(0, materialCategories[categoryIndex].materials.Count);
            return materialCategories[categoryIndex].materials[randomIndex];
        }
        return null;
    }
}