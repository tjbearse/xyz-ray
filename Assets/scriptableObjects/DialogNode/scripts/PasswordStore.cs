using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PasswordStore {
	static public string password = "hunter2";
	static public void setPassword(string password) {
		PasswordStore.password = password;
	}
}
