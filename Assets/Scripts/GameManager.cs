using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    private Image m_YouWinScreen;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Init();
    }

    void OnLevelWasLoaded(int index) {
        Init();
    }

    void Init() {
        m_YouWinScreen = GameObject.Find("YouWin").GetComponent<Image>();
    }

    void Update() {
        if (m_ShowWinScreen) {
            m_YouWinScreen.fillAmount += (1.0f / winAnimateLength) * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Return)) {
                Reset();
                SceneManager.LoadScene(0);
            }
        }
    }

    private void Reset() {
        m_ShowWinScreen = false;
    }

    bool m_ShowWinScreen = false;
    public float winAnimateLength = 3.0f;
    public void ShowWinScreen() {
        m_ShowWinScreen = true;
    }

}
