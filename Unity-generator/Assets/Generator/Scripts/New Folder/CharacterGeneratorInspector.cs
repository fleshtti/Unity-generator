using UnityEditor;
using UnityEngine;

namespace Generator.Scripts.New_Folder
{
    /// <summary>
    /// Custom editor class for inspecting CharacterGenerator components
    /// </summary>
    [CustomEditor(typeof(CharacterGenerator))]
    public class CharacterGeneratorInspector : UnityEditor.Editor
    {
        // Stored reference to the character generator being targeted
        private CharacterGenerator _characterGenerator;

        // The override of the inspector GUI will draw this instead of the default CharacterGenerator component inspector
        public override void OnInspectorGUI()
        {
            if (_characterGenerator == null) return;

            // Changing CharacterGenerator's public fields
            EditorGUI.BeginChangeCheck();
            _characterGenerator.characterMaterial = (Material)EditorGUILayout.ObjectField(
                "Character Material",
                _characterGenerator.characterMaterial,
                typeof(Material),
                false
            );
            _characterGenerator.characterRenderer = (Renderer)EditorGUILayout.ObjectField(
                "Character Renderer",
                _characterGenerator.characterRenderer,
                typeof(Renderer),
                true
            );

            EditorGUILayout.Space(10);

            _characterGenerator.characterData = (CharacterData)EditorGUILayout.ObjectField(
                "Character Data",
                _characterGenerator.characterData,
                typeof(CharacterData),
                false
            );

            // Instructing Unity that the CharacterGenerator needs to be serialized since changes were made
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(_characterGenerator);

            EditorGUILayout.Space(10);

            // Disable attempting to create character if required fields aren't assigned
            GUI.enabled =
                _characterGenerator != null &&
                _characterGenerator.characterMaterial != null &&
                _characterGenerator.characterRenderer != null &&
                _characterGenerator.characterData != null;

            // Access to CharacterGenerator's functionalities
            if (GUILayout.Button("Create Character"))
            {
                if (_characterGenerator != null)
                    _characterGenerator.CreateCharacter();
                else
                    Debug.Log("CharacterGenerator: Character Generator is null!");
            }

            // Ensure GUI is enabled at the end to avoid messing up other GUI elements
            GUI.enabled = true;
        }

        private void OnEnable()
        {
            // Acquiring the CharacterGenerator reference
            _characterGenerator = (CharacterGenerator)target;
        }
    }
}
