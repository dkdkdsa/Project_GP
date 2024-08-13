using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityToolbarExtender;

static class ToolbarStyles
{
	public static readonly GUIStyle commandButtonStyle;
	public static readonly GUIStyle dropdownButtonStyle;

	static ToolbarStyles()
	{
		commandButtonStyle = new GUIStyle("Command")
		{
			fontSize = 15,
			alignment = TextAnchor.MiddleCenter,
			imagePosition = ImagePosition.ImageAbove,
			fontStyle = FontStyle.Bold,
		};
		dropdownButtonStyle = new GUIStyle("Dropdown")
		{
			fontSize = 15,
			alignment = TextAnchor.MiddleLeft,
			fontStyle = FontStyle.Normal,
			stretchWidth = false,
			padding = new RectOffset(5, 25, 0, 0),
		};
	}
}

[InitializeOnLoad]
public class SceneSwitchLeftButton
{
	static SceneSwitchLeftButton()
	{
		ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
	}

	static void OnToolbarGUI()
	{
		GUILayout.FlexibleSpace();

		if (GUILayout.Button(new GUIContent("B", "Start BootStrap Scene"), ToolbarStyles.commandButtonStyle))
		{
			SceneHelper.StartScene("BootStrap");
		}
	}
}

static class SceneHelper
{
	static string sceneToOpen;

	public static void StartScene(string sceneName)
	{
		if (EditorApplication.isPlaying)
		{
			EditorApplication.isPlaying = false;
		}

		sceneToOpen = sceneName;
		EditorApplication.update += OnUpdate;
	}

	static void OnUpdate()
	{
		if (sceneToOpen == null ||
			EditorApplication.isPlaying || EditorApplication.isPaused ||
			EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
		{
			return;
		}

		EditorApplication.update -= OnUpdate;

		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
		{
			// need to get scene via search because the path to the scene
			// file contains the package version so it'll change over time
			string[] guids = AssetDatabase.FindAssets("t:scene " + sceneToOpen, null);
			if (guids.Length == 0)
			{
				Debug.LogWarning("Couldn't find scene file");
			}
			else
			{
				string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
				EditorSceneManager.OpenScene(scenePath);
				EditorApplication.isPlaying = true;
			}
		}
		sceneToOpen = null;
	}
}