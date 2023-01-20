using UnityEngine;
using UnityEngine.UI;

sealed public class HealthView : MonoBehaviour
{
    public Image healthBar;
    public GameObject floatingTextPrefab;
    public Transform parent;

    public void UpdateHealthBar((float, float) health) => healthBar.fillAmount = health.Item1 / health.Item2;
    public void CreateTextChangedHealth(int amountDamage) 
    {
       GameObject go = Instantiate(floatingTextPrefab, parent);
       FloatingText floatingText = go.GetComponent<FloatingText>();
       floatingText.damageText.text = amountDamage.ToString();
    }
}
