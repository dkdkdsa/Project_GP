using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityToolbarExtender;

[InitializeOnLoad]
public class SceneSwitchDropdownEditor
{
    private const string SceneFolderName = "01_Scenes";

    static SceneSwitchDropdownEditor()
	{
		ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
	}

	static void OnToolbarGUI()
	{
        Scene activeScene = EditorSceneManager.GetActiveScene();
        if (EditorGUILayout.DropdownButton(new GUIContent(activeScene.name), FocusType.Passive, ToolbarStyles.dropdownButtonStyle))
		{
			string[] guids = AssetDatabase.FindAssets("t:scene", null);

			var menu = new GenericMenu();
			foreach(var guid in guids)
			{
				string scenePath = AssetDatabase.GUIDToAssetPath(guid);
                if (scenePath.IndexOf(SceneFolderName) == -1) continue;
                string dropdownName = scenePath.Substring(scenePath.IndexOf(SceneFolderName) + SceneFolderName.Length + 1);
                dropdownName = dropdownName.Substring(0, dropdownName.IndexOf('.'));
				menu.AddItem(new GUIContent(dropdownName), false, DropdownHandler, guid);
			}
			Rect lastRect = GUILayoutUtility.GetLastRect();
			lastRect.y += ToolbarStyles.dropdownButtonStyle.fixedHeight;
			menu.DropDown(lastRect);
		}
	}

	static void DropdownHandler(object obj)
	{
		if (EditorApplication.isPlaying || EditorApplication.isPaused ||
			EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
		{
			return;
		}

		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
		{
			string scenePath = AssetDatabase.GUIDToAssetPath((string)obj);
			EditorSceneManager.OpenScene(scenePath);
		}
	}
}
