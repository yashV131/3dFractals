using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This helps switch from scene to scene upon clicking buttons
public class ChangeScenes : MonoBehaviour
{
    public void GotoGreekCrossScene()
    {
        SceneManager.LoadScene("GreekCross");
    }

    public void GotoMandelBulbScene()
    {
        SceneManager.LoadScene("PowerOf8Mandel");
    }

    public void GotoMengerSpongeScene()
    {

        SceneManager.LoadScene("MengerSponge");
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GotoAntiCrossMengerScene()
    {
        SceneManager.LoadScene("CrossOnlyMenger");
    }

    public void GotoSnowFlakeScene() {
        SceneManager.LoadScene("SnowFlake");
    }
}
 