using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem.UnityGUI;

namespace PixelCrushers.DialogueSystem.Demo
{

    /// <summary>
    /// This script provides a rudimentary main menu for the Dialogue System's Demo.
    /// </summary>
    [AddComponentMenu("")] // Use wrapper.
    public class DemoMenu : MonoBehaviour
    {
        public KeyCode menuKey = KeyCode.Escape;
        public GUISkin guiSkin;
        public bool closeWhenQuestLogOpen = true;
        public bool lockCursorDuringPlay = false;

        public UnityEvent onOpen = new UnityEvent();
        public UnityEvent onClose = new UnityEvent();

        private QuestLogWindow questLogWindow = null;
        private bool isMenuOpen = false;
        private Rect windowRect = new Rect(Screen.width/2-200f, Screen.height/2-200f, 400f, 400f);
        private ScaledRect scaledRect = ScaledRect.FromOrigin(ScaledRectAlignment.MiddleCenter, ScaledValue.FromPixelValue(300), ScaledValue.FromPixelValue(320));

        public SettingsObject settings => SettingsObject.Instance;
        void Start()
        {
            if (questLogWindow == null) questLogWindow = FindObjectOfType<QuestLogWindow>();
            settings.transform.Find("Settings").Find("CloseBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.enabled = true;
            });
        }

        void Update()
        {
            if (InputDeviceManager.IsKeyDown(menuKey) && !DialogueManager.isConversationActive && !IsQuestLogOpen())
            {
                SetMenuStatus(!isMenuOpen);
            }
            if (lockCursorDuringPlay)
            {
                CursorControl.SetCursorActive(DialogueManager.isConversationActive || isMenuOpen || IsQuestLogOpen());
            }
            if (isMenuOpen)
            {
                windowRect = new Rect(Screen.width / 2 - 200f, Screen.height / 2 - 200f, 400f, 400f);
            }
        }

        public virtual void OnGUI()
        {
            if (isMenuOpen && !IsQuestLogOpen())
            {
                if (guiSkin != null)
                {
                    GUI.skin = guiSkin;
                }
                windowRect = GUI.Window(0, windowRect, WindowFunction, "菜单");
            }
        }

        private void WindowFunction(int windowID)
        {
            if (GUI.Button(new Rect(60, 90, windowRect.width - 120, 48), "任务列表"))
            {
                if (closeWhenQuestLogOpen) SetMenuStatus(false);
                OpenQuestLog();
            }
            if (GUI.Button(new Rect(60, 150, windowRect.width - 120, 48), "设置"))
            {
                settings.gameObject.SetActive(true);
                this.enabled = false;
            }
            if (GUI.Button(new Rect(60, 210, windowRect.width - 120, 48), "关闭菜单"))
            {
                SetMenuStatus(false);
            }
        }

        public void Open()
        {
            SetMenuStatus(true);
        }

        public void Close()
        {
            SetMenuStatus(false);
        }
        public void CloseCursor()
        {
            isMenuOpen = false;
        }
        private void SetMenuStatus(bool open)
        {
            isMenuOpen = open;
            if (open) windowRect = scaledRect.GetPixelRect();
            if (open) onOpen.Invoke(); else onClose.Invoke();
        }

        private bool IsQuestLogOpen()
        {
            return (questLogWindow != null) && questLogWindow.isOpen;
        }

        private void OpenQuestLog()
        {
            if ((questLogWindow != null) && !IsQuestLogOpen())
            {
                questLogWindow.Open();
            }
        }

        private void SaveGame()
        {
            var saveSystem = FindObjectOfType<SaveSystem>();
            if (saveSystem != null)
            {
                SaveSystem.SaveToSlot(1);
            }
            else
            {
                string saveData = PersistentDataManager.GetSaveData();
                PlayerPrefs.SetString("SavedGame", saveData);
                Debug.Log("Save Game Data: " + saveData);
            }
            DialogueManager.ShowAlert("Game saved.");
        }

        private void LoadGame()
        {
            PersistentDataManager.LevelWillBeUnloaded();
            var saveSystem = FindObjectOfType<SaveSystem>();
            if (saveSystem != null)
            {
                if (SaveSystem.HasSavedGameInSlot(1))
                {
                    SaveSystem.LoadFromSlot(1);
                    DialogueManager.ShowAlert("Game loaded.");
                }
                else
                {
                    DialogueManager.ShowAlert("Save a game first.");
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("SavedGame"))
                {
                    string saveData = PlayerPrefs.GetString("SavedGame");
                    Debug.Log("Load Game Data: " + saveData);
                    LevelManager levelManager = FindObjectOfType<LevelManager>();
                    if (levelManager != null)
                    {
                        levelManager.LoadGame(saveData);
                    }
                    else
                    {
                        PersistentDataManager.ApplySaveData(saveData);
                        DialogueManager.SendUpdateTracker();
                    }
                    DialogueManager.ShowAlert("Game loaded.");
                }
                else
                {
                    DialogueManager.ShowAlert("Save a game first.");
                }
            }
        }

    }

}
