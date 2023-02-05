using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private StatusObject gameStatus;

    private SceneHandler sceneHandler;

    private const int GRANDMAHOUSE = 0;
    private const int TPHOUSE = 1;
    private const int BAR = 2;

    private void Awake() {
        sceneHandler = GetComponent<SceneHandler>();
    }

    //private void Update() {
    //    CheckStatus();
    //    if (activeScene != targetScene) {
    //        sceneHandler.CreateTransition(targetScene);
    //    }
    //}

    private int UpdateStatus() {
        switch (gameStatus.level) {
            case StatusObject.Level.Menu1:
                gameStatus.level = StatusObject.Level.TeenageYears;
                return TPHOUSE;
            case StatusObject.Level.TeenageYears:
                gameStatus.level = StatusObject.Level.Menu2;
                return GRANDMAHOUSE;
            case StatusObject.Level.Menu2:
                gameStatus.level = StatusObject.Level.AdultYears;
                return BAR;
            case StatusObject.Level.AdultYears:
                gameStatus.level = StatusObject.Level.Menu3;
                return GRANDMAHOUSE;
            case StatusObject.Level.Menu3:
                gameStatus.level = StatusObject.Level.TeenageYears;
                return TPHOUSE;
            case StatusObject.Level.FightLostMenu:
                gameStatus.level = StatusObject.Level.Menu2;
                return GRANDMAHOUSE;
            default:
                break;
        }
        return GRANDMAHOUSE;
    }

    public void NextLevel() {
        int nextLevel = UpdateStatus();
        sceneHandler.CreateTransition(nextLevel);
    }
}