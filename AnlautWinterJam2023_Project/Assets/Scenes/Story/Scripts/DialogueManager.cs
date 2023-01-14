using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Start()
    {
        LoadStory();
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

            _currentLine = _storyScript.Continue();
            _displayLineCoroutine = StartCoroutine(DisplayLine(_currentLine));
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
}
