using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

sealed public class Cell : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public bool opened;
    public TMP_Text closedCellText;
    public Cell collisedCell;
    public WeaponData weaponData;

    private Vector3 startPosition;

    private void Start() => startPosition = transform.position;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("UIButton"))
        {
            collisedCell = other.transform.GetComponent<Cell>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) => collisedCell = null;

    public void AddWeapon(WeaponData weapon) 
    {
        if(weapon != null)
        {
            weaponData = weapon;
            closedCellText.text = $"LVL {weapon.level}";
        }
        else 
        {
            weaponData = null;
            closedCellText.text = $" ";
        }
    }

    private void MergeWithCollisedCell()
    {
        if(collisedCell != null && weaponData.level == collisedCell.weaponData.level && weaponData != null && weaponData.level != 0)
        {
            collisedCell.weaponData.UpLevel();
            weaponData = null;
            opened = true;
            collisedCell.UpdateText();
            UpdateText();
        }
    }

    public void UpdateText() 
    {   if(weaponData == null)
        {
            closedCellText.text = $" ";
        }
        else closedCellText.text = $"LVL {weaponData.level}";
    }

    public void OnDrag(PointerEventData eventData) => transform.position = eventData.pointerCurrentRaycast.screenPosition;
    public void OnEndDrag(PointerEventData eventData) 
    {
        transform.position = startPosition;
        MergeWithCollisedCell();
    } 
}