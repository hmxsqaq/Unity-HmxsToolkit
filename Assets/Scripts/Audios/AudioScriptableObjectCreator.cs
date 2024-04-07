using UnityEditor;
using UnityEngine;

namespace Audios
{
    public static class AudioScriptableObjectCreator
    {
        // [MenuItem("Assets/Create/Audio Asset from Clip", true)]
        // private static bool CreateAudioAssetValidation()
        // {
        //     // 验证当前选中的对象是否为音频资产
        //     return Selection.activeObject && Selection.activeObject is AudioClip;
        // }
        //
        // [MenuItem("Assets/Create/Audio Asset from Clip")]
        // private static void CreateAudioAsset()
        // {
        //     AudioClip selectedClip = Selection.activeObject as AudioClip;
        //     if (selectedClip != null)
        //     {
        //         Audio asset = ScriptableObject.CreateInstance<Audio>();
        //         asset.clip = selectedClip;
        //
        //         string path = AssetDatabase.GetAssetPath(selectedClip);
        //         path = path.Replace(".mp3", ".asset").Replace(".wav", ".asset"); // 根据需要处理其他音频格式
        //         AssetDatabase.CreateAsset(asset, path);
        //         AssetDatabase.SaveAssets();
        //
        //         EditorUtility.FocusProjectWindow();
        //         Selection.activeObject = asset;
        //     }
        // }
    }
}