using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Build : MonoBehaviour
{
	static string[] scenes = {"Assets/Scenes/main scene.unity"};

	//$ Unity -quit -batchmode -executeMethod Build.BuildWebGL
	static void BuildWebGL() {
		BuildPipeline.BuildPlayer(scenes, "builds/webgl", BuildTarget.WebGL, BuildOptions.None);
	}
}
