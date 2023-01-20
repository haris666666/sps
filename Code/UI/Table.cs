using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed public class Table : MonoBehaviour
{
    [SerializeField] private List<Cell> cells = new List<Cell>();
    [SerializeField] private Character character;
    private Cell currentCell;

    public void CreateGun()
    {
        Cell cell = FindCell(true);
        cell.AddWeapon(new WeaponData(0, 1, 35, 1, new RangeAttackBehaviour()));
        cell.opened = false;
    }
    public void AddNewWeaponToCharacter() 
    {
        WeaponData weapon = FindBestWeapon();
        character.ChangeWeapon(weapon);
    }
    private Cell FindCell(bool openedCell)
    {
        for(int i = 0; i < cells.Count; i++)
        {
            if(cells[i].opened == openedCell)
                return cells[i];
        }
        return null;
    }
    private WeaponData FindBestWeapon()
    {
        WeaponData weapon = new WeaponData();
        for(int i = 0; i < cells.Count; i++)
        {
            if(cells[i].weaponData != null && cells[i].weaponData.level > weapon.level)
                weapon = cells[i].weaponData;
        }
        return weapon;
    }
}