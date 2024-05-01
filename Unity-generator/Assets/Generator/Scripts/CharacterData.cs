using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Generator
{
    // Define an enumeration for different character classes
    public enum CharacterClass
    {
        Rogue,
        Trader,
        Fighter
    }

    // ScriptableObject to hold character data
    [CreateAssetMenu(fileName = "NewCharacter", menuName = "Character")]
    public class CharacterData : ScriptableObject
    {
        [FormerlySerializedAs("Body")] public List<GameObject> body;
        [FormerlySerializedAs("Armor")] public List<GameObject> armor;
        [FormerlySerializedAs("HatsgearPrefab")] public List<GameObject> hatsgearPrefab;
        [FormerlySerializedAs("PantsPrefab")] public List<GameObject> pantsPrefab;
        [FormerlySerializedAs("UpperBodyPrefab")] public List<GameObject> upperBodyPrefab;
        [FormerlySerializedAs("Accessoriesies")] public List<GameObject> accessoriesies;
        [FormerlySerializedAs("Eye")] public List<GameObject> eye;

        // Add a field to store the character class
        public CharacterClass characterClass;

        // Method to generate random data for the character
        public void GenerateRandomData()
        {
            // Generate clothing data based on character class
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

        // Method to generate random data for a fighter character
        private void GenerateFighterData()
        {
            // Select random body, hat, pants, armor, accessories, and upper body prefabs
            GameObject selectedBody = GetRandomPrefabFromList(body);
            GameObject selectedHat = GetRandomPrefabFromList(hatsgearPrefab);
            GameObject selectedPants = GetRandomPrefabFromList(pantsPrefab);
            GameObject selectedUpperBody = GetRandomPrefabFromList(upperBodyPrefab);
            GameObject selectedArmor = GetRandomPrefabFromList(armor);
            GameObject selectedAccessories = GetRandomPrefabFromList(accessoriesies);
            GameObject selectedEye = GetRandomPrefabFromList(eye);

            // Set materials for each object
            // SetRandomMaterial(selectedBody);
            // SetRandomMaterial(selectedHat);
            // SetRandomMaterial(selectedPants);
            // SetRandomMaterial(selectedUpperBody);
            // SetRandomMaterial(selectedArmor);
            // SetRandomMaterial(selectedAccessories);
            // SetRandomMaterial(selectedEye);
        }

        // Method to generate random data for a rogue character
        private void GenerateRogueData()
        {
            // Select random body, hat, pants, accessories, and upper body prefabs
            GameObject selectedBody = GetRandomPrefabFromList(body);
            GameObject selectedHat = GetRandomPrefabFromList(hatsgearPrefab);
            GameObject selectedPants = GetRandomPrefabFromList(pantsPrefab);
            GameObject selectedUpperBody = GetRandomPrefabFromList(upperBodyPrefab);
            GameObject selectedAccessories = GetRandomPrefabFromList(accessoriesies);
            GameObject selectedEye= GetRandomPrefabFromList(eye);

            // Set materials for each object
            // SetRandomMaterial(selectedBody);
            // SetRandomMaterial(selectedHat);
            // SetRandomMaterial(selectedPants);
            // SetRandomMaterial(selectedUpperBody);
            // SetRandomMaterial(selectedAccessories);
            // SetRandomMaterial(selectedEye);
        }

        // Method to generate random data for a trader character
        private void GenerateTraderData()
        {
            // Select random body, hat, pants, accessories, and upper body prefabs
            GameObject selectedBody = GetRandomPrefabFromList(body);
            GameObject selectedHat = GetRandomPrefabFromList(hatsgearPrefab);
            GameObject selectedPants = GetRandomPrefabFromList(pantsPrefab);
            GameObject selectedUpperBody = GetRandomPrefabFromList(upperBodyPrefab);
            GameObject selectedAccessories = GetRandomPrefabFromList(accessoriesies);
            GameObject selectedEye= GetRandomPrefabFromList(eye);

            // Set materials for each object
            // SetRandomMaterial(selectedBody);
            // SetRandomMaterial(selectedHat);
            // SetRandomMaterial(selectedPants);
            // SetRandomMaterial(selectedUpperBody);
            // SetRandomMaterial(selectedAccessories);
            // SetRandomMaterial(selectedEye);
        }

        // Method to set a random material to a game object
        // private void SetRandomMaterial(GameObject obj)
        // {
        //     if (obj != null)
        //     {
        //         Renderer renderer = obj.GetComponent<Renderer>();
        //         if (renderer != null)
        //         {
        //             // Get random material and assign it to the object
        //             Material[] materials = renderer.sharedMaterials;
        //             if (materials.Length > 0)
        //             {
        //                 int randomIndex = Random.Range(0, materials.Length);
        //                 renderer.material = materials[randomIndex];
        //             }
        //         }
        //     }
        // }

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
