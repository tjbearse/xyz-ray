using UnityEngine;

[CreateAssetMenu(fileName = "Clickable", menuName = "ScriptableObjects/ClickableObject", order = 1)]
public class ClickableObject : ScriptableObject {
	[TextArea(2, 5)]
	public string consoleText;
}
