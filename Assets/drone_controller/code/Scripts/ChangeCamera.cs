using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject DroveCamera;
    public GameObject PersonCamera;
    public Plook LookScript;
    public Canvas PlayerUI;
    // Start is called before the first frame update
    public void initial()
    {
        ChangeToPerson();
    }
    public void end()
    {
        ChangeToDrove();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)&&PersonCamera.activeInHierarchy==true)
        {
            ChangeToDrove();
        }
        else if(Input.GetKeyDown(KeyCode.R)&&DroveCamera.activeInHierarchy == true)
        {
            ChangeToPerson();
        }
    }
    public void ChangeToPerson()
    {
        LookScript.enabled = true;
        DroveCamera.SetActive(false);
        PersonCamera.SetActive(true);
        PlayerUI.enabled = true;
        SetLockCursor(true);
    }
    public void ChangeToDrove()
    {
        LookScript.enabled = false;
        DroveCamera.SetActive(true);
        PersonCamera.SetActive(false);
        PlayerUI.enabled = false;
        SetLockCursor(false);
    }
    public void SetLockCursor(bool x)
    {
        if(x)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
