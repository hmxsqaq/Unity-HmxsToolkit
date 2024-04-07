using Hmxs.Toolkit.Base.Pools;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Audios
{
    [CreateAssetMenu(fileName = "NewAudio", menuName = "Hmxs/Audio")]
    public class Audio : ScriptableObject
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private AudioType type;
        [SerializeField] private float defaultVolume = 1;
        [SerializeField] private float defaultPitch = 1;

        public AudioClip Clip => clip;
        public AudioType Type => type;

        public void Play(int? volume = null,int? pitch = null, Vector3? position = null)
        {

        }

        private void Play(AudioClip audioClip, float volume, float pitch, Vector3? position = null)
        {

        }

        private void Play(AudioClip audioClip, float volume, float pitch, Transform fellow = null, Vector3 offset = default)
        {

        }


        private static AudiosManager _manager;

        private static AudiosManager Manager
        {
            get
            {
                if (_manager != null) return _manager;

                _manager = Object.FindObjectOfType<AudiosManager>();
                if (_manager != null) return _manager;

                _manager = new GameObject("AudiosManager").AddComponent<AudiosManager>();
                DontDestroyOnLoad(_manager.gameObject);
                return _manager;
            }
        }

        private class AudiosManager : MonoBehaviour
        {

            private void Init()
            {

            }
        }
    }
}