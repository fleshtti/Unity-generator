using System.Collections.Generic;
using UnityEngine;

namespace Generator
{
    public enum CharacterClass
    {
        Rogue,
        Trader,
        Fighter
    }

    [CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        public List<GameObject> body;
        public List<GameObject> armor;
        public List<GameObject> hatsgearPrefab;
        public List<GameObject> pantsPrefab;
        public List<GameObject> upperBodyPrefab;
        public List<GameObject> accessoriesies;
        public List<GameObject> eye;
        public List<GameObject> bottomLayer;

        public CharacterClass characterClass;

        // Reference to MaterialManager
        public MaterialManager materialManager;

        public void GenerateRandomData()
        {
            switch (characterClass)
            {
                case CharacterClass.Fighter:
                    GenerateFighterData();
                    break;
                case CharacterClass.Rogue:
                    GenerateRogueData();
                    break;
                case CharacterClass.Trader:
                    GenerateTraderData();
                    break;
            }
        }

        private void GenerateFighterData()
        {
            SetRandomMaterials(GetRandomPrefabFromList(body), MaterialCategory.Body);
            SetRandomMaterials(GetRandomPrefabFromList(hatsgearPrefab), MaterialCategory.Hatsgear);
            SetRandomMaterials(GetRandomPrefabFromList(pantsPrefab), MaterialCategory.Pants);
            SetRandomMaterials(GetRandomPrefabFromList(upperBodyPrefab), MaterialCategory.UpperBody);
            SetRandomMaterials(GetRandomPrefabFromList(armor), MaterialCategory.Armor);
            SetRandomMaterials(GetRandomPrefabFromList(accessoriesies), MaterialCategory.Accessories);
            SetRandomMaterials(GetRandomPrefabFromList(eye), MaterialCategory.Eye);
            SetRandomMaterials(GetRandomPrefabFromList(bottomLayer), MaterialCategory.BottomLayer);
        }

        private void GenerateRogueData()
        {
            SetRandomMaterials(GetRandomPrefabFromList(body), MaterialCategory.Body);
            SetRandomMaterials(GetRandomPrefabFromList(hatsgearPrefab), MaterialCategory.Hatsgear);
            SetRandomMaterials(GetRandomPrefabFromList(pantsPrefab), MaterialCategory.Pants);
            SetRandomMaterials(GetRandomPrefabFromList(upperBodyPrefab), MaterialCategory.UpperBody);
            SetRandomMaterials(GetRandomPrefabFromList(accessoriesies), MaterialCategory.Accessories);
            SetRandomMaterials(GetRandomPrefabFromList(eye), MaterialCategory.Eye);
            SetRandomMaterials(GetRandomPrefabFromList(bottomLayer), MaterialCategory.BottomLayer);
        }

        private void GenerateTraderData()
        {
            SetRandomMaterials(GetRandomPrefabFromList(body), MaterialCategory.Body);
            SetRandomMaterials(GetRandomPrefabFromList(hatsgearPrefab), MaterialCategory.Hatsgear);
            SetRandomMaterials(GetRandomPrefabFromList(pantsPrefab), MaterialCategory.Pants);
            SetRandomMaterials(GetRandomPrefabFromList(upperBodyPrefab), MaterialCategory.UpperBody);
            SetRandomMaterials(GetRandomPrefabFromList(accessoriesies), MaterialCategory.Accessories);
            SetRandomMaterials(GetRandomPrefabFromList(eye), MaterialCategory.Eye);
            SetRandomMaterials(GetRandomPrefabFromList(bottomLayer), MaterialCategory.BottomLayer);
        }

        // Method to set random materials to an object using the category from MaterialManager
        private void SetRandomMaterials(GameObject obj, MaterialCategory category)
        {
            if (obj != null && materialManager != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material randomMaterial = materialManager.GetRandomMaterialFromCategory(category);
                    if (randomMaterial != null)
                    {
                        Material[] materials = renderer.materials;
                        for (int i = 0; i < materials.Length; i++)
                        {
                            materials[i] = randomMaterial;
                        }
                        renderer.materials = materials;
                    }
                }
            }
        }

        // Method to get a random prefab from a list
        private GameObject GetRandomPrefabFromList(List<GameObject> prefabList)
        {
            if (prefabList != null && prefabList.Count > 0)
            {
                int randomIndex = Random.Range(0, prefabList.Count);
                return prefabList[randomIndex];
            }
            else
            {
                return null;
            }
        }
    }
}
