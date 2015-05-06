using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUi : MonoBehaviour {
    public RectTransform lifeBar;
    public RectTransform[] abilities = new RectTransform[4];
    public float LifeBarWidth;

    public void Start()
    {
        LifeBarWidth = lifeBar.anchorMax.x;

    }

    public void SetAbilityCooldown(float cooldown, int ability)
    {
        abilities[ability].GetComponent<Image>().color = new Color(1, 1, 1, Mathf.Clamp(cooldown, 0, 1));
    }

    public void SetHealthBar(float health, float maxHealth)
    {
        lifeBar.anchorMax = new Vector2((health / maxHealth) * LifeBarWidth, lifeBar.anchorMax.y);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
