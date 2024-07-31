using Assets.CodeBase.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.GameEnvironment.UI
{
    public class DialogWindow : MonoBehaviour
    {
        [SerializeField] private List<string> _texts;
        [SerializeField] private float _typingSpeed;
        [SerializeField] private DialogData _dialogData;
        [SerializeField] private GameObject _firstCharFade;
        [SerializeField] private GameObject _secondCharFade;
        //[SerializeField] private Image _firstCharImage;
        //[SerializeField] private Image _secondCharImage;
        [SerializeField] private TMP_Text _firstCharText;
        [SerializeField] private TMP_Text _secondCharText;

        private int _textNumber;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = Camera.main;
            _texts = _dialogData.GetLocalizedDialog().ToList();            
        }

        private void Start()
        {
            StartCoroutine(ShowDialog());
        }
        
        private IEnumerator ShowDialog()
        {
            while (_textNumber != _texts.Count)
            {
                StartCoroutine(DisplayLine(_firstCharText));
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
                SetNextText(_firstCharText);
                DoFade();
                StartCoroutine(DisplayLine(_secondCharText));
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
                SetNextText(_secondCharText);
                DoFade();
                yield return null;
            }

            gameObject.SetActive(false);
        }

        private IEnumerator DisplayLine(TMP_Text text)
        {
            text.text = _texts[_textNumber];
            text.maxVisibleCharacters = 0;

            for (int i = 0; i < text.text.Length; i++)
            {
                text.maxVisibleCharacters++;
                yield return new WaitForSeconds(_typingSpeed);
            }
        }

        private void SetNextText(TMP_Text text)
        {
            text.maxVisibleCharacters = text.text.Length;
            _textNumber++;
        }

        private void DoFade()
        {
            if (_firstCharFade.activeSelf == true)
            {
                _firstCharFade.SetActive(false);
                _secondCharFade.SetActive(true);
            }
            else
            {
                _firstCharFade.SetActive(true);
                _secondCharFade.SetActive(false);
            }
        }
    }
}