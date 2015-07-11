using UnityEngine;
using System.Collections;

public class ButtomActionLoadLevel : ButtomAction {
	public string levelName= "Default";


	override public void ExecuteAction()
	{
		Application.LoadLevel(levelName);
	}
}
