using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MaterialManager))]
public class MaterialManagerEditor : Editor
{
    private SerializedProperty materialCategories;

    private void OnEnable()
    {
        materialCategories = serializedObject.FindProperty("materialCategories");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        MaterialManager materialManager = (MaterialManager)target;

        // Button to add a new category
        if (GUILayout.Button("Add Category"))
        {
            materialManager.materialCategories.Add(new MaterialManager.MaterialCategoryData { category = MaterialCategory.Body, materials = new List<Material>() });
        }

        // Display categories and materials in the inspector
        for (int i = 0; i < materialCategories.arraySize; i++)
        {
            SerializedProperty categoryProperty = materialCategories.GetArrayElementAtIndex(i);
            SerializedProperty categoryEnumProperty = categoryProperty.FindPropertyRelative("category");
            SerializedProperty materialsProperty = categoryProperty.FindPropertyRelative("materials");

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.PropertyField(categoryEnumProperty);

            // Button to add a material to the category
            if (GUILayout.Button("Add Material to " + ((MaterialCategory)categoryEnumProperty.enumValueIndex).ToString()))
            {
                materialsProperty.arraySize++;
            }

            // Display materials in the category
            for (int j = 0; j < materialsProperty.arraySize; j++)
            {
                SerializedProperty materialProperty = materialsProperty.GetArrayElementAtIndex(j);
                materialProperty.objectReferenceValue = EditorGUILayout.ObjectField("Material " + (j + 1), materialProperty.objectReferenceValue, typeof(Material), false);
            }

            // Button to remove the category
            if (GUILayout.Button("Remove Category"))
            {
                materialCategories.DeleteArrayElementAtIndex(i);
            }

            EditorGUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(materialManager);
        }
    }
}
