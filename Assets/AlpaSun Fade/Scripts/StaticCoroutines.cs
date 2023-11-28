using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace AlpaSunFade
{
	/// <summary>
	/// A colletion of coroutines to handle the fade transitions and wait times
	/// </summary>
	internal static class StaticCoroutines
	{
		/// <summary>
		/// Locks the controls by setting the control map to one that doesn't handle any input. Once the coroutine is complete,
		/// the controls will be set back to their original map.
		/// </summary>
		/// <param name="duration">Duration in seconds to lock the controls. Should be the same or slightly longer then the
		/// fade duration</param>
		/// <param name="playerInput">PlayerInput object used to set the map</param>
		/// <returns></returns>
		internal static IEnumerator LockControls(float duration, PlayerInput playerInput)
		{
			var actionMapStart = playerInput.currentActionMap;
			playerInput.currentActionMap = playerInput.actions.FindActionMap(nameOrId: "LockControls");

			yield return new WaitForSeconds(duration);

			playerInput.currentActionMap = actionMapStart;

			yield return null;
		}

		/// <summary>
		/// Handles the opacity of the visual element to control the fade
		/// </summary>
		/// <param name="container">UI Toolkit Visual Element container to fade</param>
		/// <param name="startOpacity">Starting opacity</param>
		/// <param name="endOpacity">Ending opacity</param>
		/// <param name="duration">Duration in seconds to fade</param>
		/// <param name="waitDuration">Time in seconds to wait before fading</param>
		internal static IEnumerator LerpVisualElementOpacity(VisualElement container, float startOpacity, float endOpacity, float duration, float waitDuration)
		{
			if(startOpacity == 0)
			{
				container.style.opacity = 0;
			}

			yield return new WaitForSeconds(waitDuration);

			container.style.transitionDuration = new List<TimeValue> { duration };
			container.style.opacity = endOpacity;
		}
	}
}