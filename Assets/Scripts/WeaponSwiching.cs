using UnityEngine;

public class WeaponSwiching : MonoBehaviour
{
    [HideInInspector]
    public int selectedWeaponInd = 0;
    public bool selectBySctrolling = false;
    public bool selectByKeyboard = true;

    // Start is called before the first frame update
    void Start()
    {
        selectWeapon(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!selectBySctrolling && !selectByKeyboard)
            selectByKeyboard = true;

        int previousSelectedWeapon = selectedWeaponInd;

        if (selectBySctrolling)
            changeBySctrolling();
        if (selectByKeyboard)
            changeByNumbers();


        if (previousSelectedWeapon != selectedWeaponInd)
        {
            selectWeapon();
        }
    }

    void selectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeaponInd)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void changeBySctrolling()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeaponInd >= transform.childCount - 1)
                selectedWeaponInd = 0;
            else
                selectedWeaponInd++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeaponInd <= 0)
                selectedWeaponInd = transform.childCount - 1;
            else
                selectedWeaponInd--;
        }
    }

    void changeByNumbers()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeaponInd = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeaponInd = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeaponInd = 2;
        }
    }
}
