using UnityEngine;
using System.Collections;

public class ButtonExitLevel : ButtomAction {

	override public void ExecuteAction()
	{
		Application.Quit ();
	}
}
