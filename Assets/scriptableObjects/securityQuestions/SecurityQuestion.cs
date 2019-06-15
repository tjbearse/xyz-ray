using UnityEngine;

[CreateAssetMenu(fileName = "Clickable", menuName = "ScriptableObjects/SecurityQuestion", order = 1)]
public class SecurityQuestion : ScriptableObject {
	public string question;
	public string answer;
}
