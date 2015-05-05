using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUi : MonoBehaviour {
    public RectTransform lifeBar;
    public RectTransform[] abilities = new RectTransform[4];

    public void SetAbilityCooldown(float cooldown, int ability)
    {
        abilities[ability].GetComponent<Image>().color = new Color(1, 1, 1, Mathf.Clamp(cooldown, 0, 1));
    }
}
