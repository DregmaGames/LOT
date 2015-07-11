using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
		public Texture2D dregmaGameLogo;
		
		public Role[] DregmaRoles;
		
		public string sceneToGoBackTo;
		
		// Credits scrolling
		private Vector2 scrollPosition;
		private float prevScrollPosition = 0f;
		private float currScrollPosition = -1f;
		private float autoScrollingSpeed = 30f;
		
		public GUIStyle titleStyle;
		public GUIStyle roleStyle;
		public GUIStyle nameStyle;
		public GUIStyle backButtonStyle;
		public GUIStyle logoStyle;
		
		// Touch controls
		private float scrollSpeed = 0f;
		private float timeTouchPhaseEnded = 0f;
		private const float inertiaDuration = 0.75f;
		private float lastDeltaPosition = 0.0f;
		
		// Font resizing according to screen size
		private float oldWidth;
		private float oldHeight;
		private float fontSize = 16;
		private const float ratio = 320;
		
		// Scrolls the credits with touch
		// http://stackoverflow.com/a/20631963
		// http://www.mindthecube.com/blog/2010/09/adding-iphone-touches-to-unitygui-scrollview
		void scrollWithTouch ()
		{
			if (Input.touchCount > 0)
			{
				autoScrollingSpeed = 0;
				
				Touch touch = Input.touches[0];
				
				if (touch.phase == TouchPhase.Began)
				{
					scrollSpeed = 0f; // fully stop drag when new touch begins
				}
				else if (touch.phase == TouchPhase.Moved)
				{
					scrollPosition.y += touch.deltaPosition.y; // drag
					
					// touch.deltaPosition must be saved for scrolling to work in Android
					// this happens because touch.deltaPosition is reset to 0
					// when touch.phase is Ended instead of keeping the last value
					lastDeltaPosition = touch.deltaPosition.y; // save deltaPosition.y
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					// impart momentum, using last delta as the starting velocity
					// ignore delta < 10; precision issues can cause ultra-high velocity
					if (Mathf.Abs(lastDeltaPosition) >= 10) 
						scrollSpeed = (int)(lastDeltaPosition / touch.deltaTime);
					
					if (scrollSpeed == 0.0f)
					{
						autoScrollingSpeed = 30f;
						currScrollPosition = -1f;
					}
					
					timeTouchPhaseEnded = Time.time; // save time when touch eded
				}
			}
			else
			{
				if ( scrollSpeed != 0.0f )
				{
					// slow down over time
					float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
					
					/*if (scrollPosition.y <= 0 || scrollPosition.y >= (numRows*rowSize.y - listSize.y))
				{
					// bounce back if top or bottom reached
					scrollVelocity = -scrollVelocity;
				}*/
					
					float frameVelocity = Mathf.Lerp(scrollSpeed, 0, t);
					scrollPosition.y += frameVelocity * Time.deltaTime;
					
					// after N seconds, we've stopped
					if (t >= 1.0f)
					{
						scrollSpeed = 0.0f;
						autoScrollingSpeed = 30f;
						currScrollPosition = -1f;
					}
				}
			}
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			scrollWithTouch ();
			
			// Change text size according to screen size
			// http://forum.unity3d.com/threads/102876-Changing-Text-Size-Relative-To-Screen
			if (oldWidth != Screen.width || oldHeight != Screen.height)
			{
				oldWidth = Screen.width;
				oldHeight = Screen.height;
				fontSize = Mathf.Min(Screen.width, Screen.height) / ratio;
				
				titleStyle.fontSize = Mathf.CeilToInt(20 * fontSize);
				roleStyle.fontSize = Mathf.CeilToInt(16 * fontSize);
				nameStyle.fontSize = Mathf.CeilToInt(16 * fontSize);
			}
			
			prevScrollPosition = scrollPosition.y;
			scrollPosition.y += Time.deltaTime * autoScrollingSpeed;
			
			if (prevScrollPosition == currScrollPosition && autoScrollingSpeed > 0)
			{
				scrollPosition.y = 0;
			}
			
			currScrollPosition = prevScrollPosition;
		}
		
		void OnGUI ()
		{
			GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height));
			
			scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUIStyle.none, GUIStyle.none);
			
			GUILayout.Space (Screen.height);
			
			
			// Logos
			
			GUILayout.Label (dregmaGameLogo, logoStyle, GUILayout.Width(Screen.width), GUILayout.Height(dregmaGameLogo.height * Screen.width / dregmaGameLogo.width));

			

			
			// Students
			
			GUILayout.Label ("Dregma Games Team", titleStyle);
			
			foreach (Role dregmaTeam in DregmaRoles)
			{
				GUILayout.Label (dregmaTeam.roleTitle, roleStyle);
				
				foreach (string name in dregmaTeam.personName)
				{
					GUILayout.Label (name, nameStyle);
				}
			}
			
	
			
			
			GUILayout.Space (Screen.height);
			
			GUILayout.EndScrollView ();
			
			if (GUILayout.Button ("Back", backButtonStyle))
			{
				Application.LoadLevel(sceneToGoBackTo);
			}
			
			GUILayout.EndArea ();
		}
	}
