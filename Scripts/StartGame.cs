using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneName = "SampleScene"; // Nome da cena do jogo

    public void StartGameScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}


