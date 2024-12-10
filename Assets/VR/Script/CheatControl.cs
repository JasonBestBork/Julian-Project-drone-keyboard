using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheatControl : MonoBehaviour
{
    // Start is called before the first frame update
    public manager manager;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;

    public GameObject panel_cheat;
    ColorBlock cb_white;
    ColorBlock cb_black;

    private void Start()
    {
        cb_white = new ColorBlock();
        cb_white.normalColor = Color.white;
        cb_white.normalColor = Color.white;
        cb_white.highlightedColor = Color.white;

        cb_black = new ColorBlock();
        cb_black.normalColor = Color.black;
        cb_black.normalColor = Color.black;
        cb_black.highlightedColor = Color.black;
    }
    public void b1_click()
    {
        manager.Rule_01_IsSccessed = !manager.Rule_01_IsSccessed;
    }
    public void b2_click()
    {
        manager.Rule_02_IsSccessed = !manager.Rule_02_IsSccessed;
    }
    public void b3_click()
    {
        manager.Rule_03_IsSccessed = !manager.Rule_03_IsSccessed;
    }
    public void b4_click()
    {
        manager.Rule_04_IsSccessed = !manager.Rule_04_IsSccessed;
    }
    public void b5_click()
    {
        manager.Rule_05_IsSccessed = !manager.Rule_05_IsSccessed;
    }
    public void b6_click()
    {
        manager.Rule_06_IsSccessed = !manager.Rule_06_IsSccessed;
    }
    public void b7_click()
    {
        manager.Rule_07_IsSccessed = !manager.Rule_07_IsSccessed;
    }
    public void b8_click()
    {
        //manager.Rule_08_IsSccessed = !manager.Rule_08_IsSccessed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Setting.Cheat)
        {
            panel_cheat.SetActive(true);
            if (manager.Rule_01_IsSccessed)
                b1.colors = cb_white;
            else
                b1.colors = cb_black;

            if (manager.Rule_02_IsSccessed)
                b2.colors = cb_white;
            else
                b2.colors = cb_black;

            if (manager.Rule_03_IsSccessed)
                b3.colors = cb_white;
            else
                b3.colors = cb_black;

            if (manager.Rule_04_IsSccessed)
                b4.colors = cb_white;
            else
                b4.colors = cb_black;

            if (manager.Rule_05_IsSccessed)
                b5.colors = cb_white;
            else
                b5.colors = cb_black;

            if (manager.Rule_06_IsSccessed)
                b6.colors = cb_white;
            else
                b6.colors = cb_black;

            if (manager.Rule_07_IsSccessed)
                b7.colors = cb_white;
            else
                b7.colors = cb_black;
            /*
            if (manager.Rule_08_IsSccessed)
                b8.colors = cb_white;
            else
                b8.colors = cb_black;
            */
        }
        else
            panel_cheat.SetActive(false);
    }
}
