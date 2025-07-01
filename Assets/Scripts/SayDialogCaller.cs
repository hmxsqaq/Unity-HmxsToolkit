using Fungus;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
	public class SayDialogCaller : MonoBehaviour
	{
		[SerializeField] private SayDialog sayDialog;

		[Button]
		private void Say(string text = "Hello~")
		{
			if (!sayDialog) return;
			sayDialog.SetActive(true);
			sayDialog.Say(
				text: text,
				clearPrevious: true,
				waitForInput: true,
				fadeWhenDone: true,
				stopVoiceover: true,
				waitForVO: false,
				voiceOverClip: null,
				onComplete: null);
		}
	}
}
