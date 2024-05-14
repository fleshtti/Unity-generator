using System.Collections.Generic;
using Generator;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    // Reference to the currently operated upon character data
    [HideInInspector] public CharacterData characterData;
    // Reference to the main material using the custom character shader, assigned through custom editor class
    [HideInInspector] public Material characterMaterial;
    // Reference to the character model's renderer so it doesn't get lost
    [HideInInspector] public Renderer characterRenderer;

    private GameObject[] _equipmentInstances;

    /// <summary>
    /// The main character creation method
    /// </summary>
    public void CreateCharacter()
    {
        // Avoid trying to create with invalid data
        if (characterData == null) { return; }

        // Clean up the previous equipment if it exists
        if (_equipmentInstances != null)
        {
            foreach (GameObject instance in _equipmentInstances)
            {
                if (instance != null)
                    DestroyImmediate(instance);
            }
        }

        if (characterRenderer) // If the character renderer has been found and assigned
        {
            // Generate random data based on character class
            characterData.GenerateRandomData();

            // Assigning materials to the character
            SetCharacterMaterial();

            // Create and equip character equipment
            CreateEquipment();
        }
    }

    internal void Randomize()
    {
        throw new System.NotImplementedException();
    }

    internal void RandomizeCat()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Creates and equips character equipment based on the generated character data
    /// </summary>
    private void CreateEquipment()
    {
        // Create and equip each piece of equipment
        List<GameObject> equipmentList = new List<GameObject>();
        equipmentList.AddRange(characterData.body);
        equipmentList.AddRange(characterData.armor);
        equipmentList.AddRange(characterData.hatsgearPrefab);
        equipmentList.AddRange(characterData.pantsPrefab);
        equipmentList.AddRange(characterData.upperBodyPrefab);
        equipmentList.AddRange(characterData.accessoriesies);
        equipmentList.AddRange(characterData.eye);

        _equipmentInstances = new GameObject[equipmentList.Count];
        for (int i = 0; i < equipmentList.Count; i++)
        {
            GameObject equipmentPrefab = equipmentList[i];
            if (equipmentPrefab != null)
            {
                GameObject equipmentInstance = Instantiate(equipmentPrefab, transform.position, transform.rotation, transform);
                _equipmentInstances[i] = equipmentInstance;

                // Set material for the equipment instance
                SetRandomMaterial(equipmentInstance);
            }
        }
    }

    /// <summary>
    /// Sets a random material to a game object's renderer
    /// </summary>
    private void SetRandomMaterial(GameObject obj)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Get random material and assign it to the object
                Material[] materials = renderer.sharedMaterials;
                if (materials.Length > 0)
                {
                    int randomIndex = Random.Range(0, materials.Length);
                    renderer.material = materials[randomIndex];
                }
            }
        }
    }

    /// <summary>
    /// Sets the material for the character model's renderer
    /// </summary>
    private void SetCharacterMaterial()
    {
        if (characterMaterial != null && characterRenderer != null)
        {
            characterRenderer.material = Instantiate(characterMaterial);
        }
    }
}