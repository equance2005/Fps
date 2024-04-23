using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTheScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //当我们在键盘上按下ESC时,退出程序
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //如果在编辑器下
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            //如果打包以后
#else
            Application.Quit();
#endif
        }
    }
}
