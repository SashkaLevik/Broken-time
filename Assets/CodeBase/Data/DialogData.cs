using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Data
{
    [CreateAssetMenu(fileName = "NewDialog", menuName = "DialogSystem/Dialog")]
    public class DialogData : ScriptableObject
    {
        public Sprite charImage;
        public string charName;

        [TextArea(3, 10)] public List<string> _enTexts;
        [TextArea(3, 10)] public List<string> _ruTexts;

        public List<string> GetLocalizedDialog()
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                return _enTexts;
            }
            return _ruTexts;
        }
    }
}