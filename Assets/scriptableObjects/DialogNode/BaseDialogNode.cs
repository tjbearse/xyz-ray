using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "DialogNode", menuName = "ScriptableObjects/SecurityQuestion", order = 1)]
abstract public class BaseDialogNode : ScriptableObject {
	abstract public string StartText();

	abstract public (string response, BaseDialogNode next) RecieveText(string answer);
}
