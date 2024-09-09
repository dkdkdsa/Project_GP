using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    public void LoadSceneNetwork(string sceneName)
    {

        NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    }

}
