using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    AsyncOperationHandle handle;

    private void OnEnable()
    {
        string sceneName = "Assets/Scenes/GameScene.unity";
        handle = Addressables.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        enabled = false;
    }

    public void ReloadScene()
    {
        Addressables.UnloadSceneAsync(handle);
        enabled = true;
    }
}
