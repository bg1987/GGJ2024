using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Lifecycle", menuName = "Lifecycle")]
public class GameLifecycle : ScriptableObject
{
    public enum GameState
    {
        Playing,
        Menu,
    }

    public string PlayingSceneName;
    public string MenuSceneName;

    private GameState _state;

    public GameState State
    {
        get
        {
            if (_state == null)
            {
                _state = GameState.Menu;
            }

            return _state;
        }
    }

    public void StartGame()
    {
        _state = GameState.Playing;
        SceneManager.LoadScene(PlayingSceneName);
    }

    public void LoseGame()
    {
        _state = GameState.Menu;
        SceneManager.LoadScene(MenuSceneName);
        Resources.UnloadAsset(IOC.Instance);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}