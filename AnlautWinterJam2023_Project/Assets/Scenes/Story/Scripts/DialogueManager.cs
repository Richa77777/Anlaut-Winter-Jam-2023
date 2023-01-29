using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJsonFile;
    private Story _storyScript;

    [SerializeField]
    private TextMeshProUGUI _dialogueField;

    [SerializeField]
    private float _typingSpeed = 0.05f;

    private Coroutine _displayLineCoroutine;
    private bool _canContinueToNextLine = false;

    private string _currentLine;

    [SerializeField]
    private GridLayoutGroup _choiceHolder;

    [SerializeField]
    private Button _choiceButtonPrefab;
    [SerializeField]
    private SpriteContainer _spriteContainer;
    [SerializeField]
    private AudioClipContainer _audioContainer;

    [SerializeField]
    private Image _currentArt;
    [SerializeField]
    private TextMeshProUGUI _currentActor;

    [SerializeField]
    private ProgressBar _bar;

    void Start()
    {
        LoadStory();
        inkFunctions();
        DisplayNextLine();
    }

    public void LoadStory()
    {
        _storyScript = new Story(_inkJsonFile.text);
    }

    public void DisplayNextLine()
    {
        if(_storyScript.canContinue)
        {
            if(_displayLineCoroutine != null)
            {
                StopCoroutine(_displayLineCoroutine);
            }

            _currentActor.text = "";
            _currentLine = _storyScript.Continue();
            _displayLineCoroutine = StartCoroutine(DisplayLine(_currentLine));
        }

        if(_storyScript.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
    }

    private void DisplayChoices()
    {
        if (_choiceHolder.GetComponentsInChildren<Button>().Length > 0) return;
        
        for(int i = 0; i < _storyScript.currentChoices.Count; i++)
        {
            var choice = _storyScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceHolder.transform, false);
    
        var buttonText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = text;

        return choiceButton;
    }

    void OnClickChoiceButton(Choice choice)
    {
        _storyScript.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
    }

    void RefreshChoiceView()
    {
        if(_choiceHolder != null)
        {
            foreach(var button in _choiceHolder.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        _dialogueField.text = "";

        _canContinueToNextLine = false;

        yield return new WaitForSeconds(0f);

        for(int i = 0; i < line.Length; i++)
        {
            _dialogueField.text = line.Substring(0, i);

            yield return new WaitForSeconds(_typingSpeed);
        }

        _canContinueToNextLine = true;
    }

    public void SkipOrNext(InputAction.CallbackContext context)
    {
        if(context.performed)//нужно для того, чтобы событие обрабатывалось один раз
        {
            if (_canContinueToNextLine)
            {
                DisplayNextLine();
            }
            else
            {
                _dialogueField.text = _currentLine;

                StopCoroutine(_displayLineCoroutine);

                _canContinueToNextLine = true;
            }
        }
    }

    private void inkFunctions()
    {
        _storyScript.BindExternalFunction("image", (int idImage) =>
        {
            _currentArt.sprite = _spriteContainer.GetImageByID(idImage);
        });

        _storyScript.BindExternalFunction("soundOn", (string soundName) =>
        {
            AudioManager.Instance.Clip = _audioContainer.GetAudioByName(soundName);
            AudioManager.Instance.StartMusic();
        });

        _storyScript.BindExternalFunction("soundOff", () =>
        {
            AudioManager.Instance.StopMusic();
        });

        _storyScript.BindExternalFunction("name", (string nameActor) =>
        {
            _currentActor.text = nameActor;
        });

        _storyScript.BindExternalFunction("next", (string nextScene) =>
        {
            LoadSceneByName.Instance.ChangeMinigame(nextScene);
        });

        _storyScript.BindExternalFunction("updateBar", (float newValue) =>
        {
            _bar.UpdateBarValue(newValue);
        });

        _storyScript.BindExternalFunction("closeBackground",() =>
        {
            GameObject background = GameObject.Find("BackgroundDText");
            if (background != null)
            {
                background.SetActive(false);
            }
        });
    }

    void OnApplicationQuit()
    {
        //PlayerPrefs.DeleteKey("currentProgress");
        //PlayerPrefs.SetFloat("currentProgress", 0f);
        PlayerPrefs.DeleteAll();

    }
}
