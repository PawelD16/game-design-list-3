using UnityEngine.SceneManagement;

public static class SceneManagerWrapper
{
    private const string WORLD_SCENE_NAME = "WorldScene";
    private const string END_SCENE_NAME = "EndScene";

    public static void LoadWorldScene() => SceneManager.LoadScene(WORLD_SCENE_NAME);
    public static void LoadEndScene() => SceneManager.LoadScene(END_SCENE_NAME);
}