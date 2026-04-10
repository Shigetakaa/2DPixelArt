using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponIconHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SecondaryWeapons secondaryWeapon;

    public void Setup(SecondaryWeapons weapon)
    {
        secondaryWeapon = weapon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ENTER");

        string text = $"{secondaryWeapon.weaponName}\n\n{secondaryWeapon.weaponDescription}";

        TooltipUI.Instance.Show(text, Input.mousePosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI.Instance.Hide();
    }
}
