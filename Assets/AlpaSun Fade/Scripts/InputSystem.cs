using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AlpaSunFade
{
	/// <summary>
	/// Handles all inputs set up in the Input System
	/// </summary>
	internal class InputSystem : MonoBehaviour
	{
		[Header("Scripts")]
		[SerializeField] TransitionPanel transitionPanelScript;

		private PlayerInput _playerInput;

		private void Awake()
		{
			_playerInput = GetComponent<PlayerInput>();
		}

		// The following two methods demonstrate how to start the fade transition after a key is pressed. The fade
		// can also be triggered in code.

		// Triggered by [SPACE] to fade out
		[UsedImplicitly]
		private void OnFadeOut()
		{
			float fadeDuration = 3;

			StartCoroutine(StaticCoroutines.LockControls(fadeDuration, _playerInput));
			transitionPanelScript.StartTransition(true, 0, fadeDuration);
		}

		// Triggered by [ESCAPE] to fade in
		[UsedImplicitly]
		private void OnFadeIn()
		{
			float fadeDuration = 4;

			StartCoroutine(StaticCoroutines.LockControls(fadeDuration, _playerInput));
			transitionPanelScript.StartTransition(false, 0, fadeDuration);
		}
	}
}