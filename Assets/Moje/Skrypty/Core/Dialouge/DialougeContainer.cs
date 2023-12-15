using UnityEngine;
using TMPro;

namespace DIALOUGE
{
[System.Serializable]

public class DialougeContainer
{
 public GameObject root;
 public NameContainer nameContainer;
 public TextMeshProUGUI dialougeText;

 public void SetDialogueColor(Color color) => dialougeText.color = color;
 public void SetDialogueFont(TMP_FontAsset font) => dialougeText.font = font;
}
}