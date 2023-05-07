using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoView : MonoBehaviour
{
    private bool _isAdd = false;

    public void VideoViewCheck(Slider _slider, VideoPlayer _videoPlayer)
    {
        IQueryDatabase queryDatabase = new BDbase();
        if ((_slider.maxValue == _slider.value || _videoPlayer.length == _videoPlayer.frame)&&_isAdd==false)
        {
            _isAdd = true;
            _slider.value = 0;
            _videoPlayer.frame = 0;
            Debug.Log("Конец видео");
            SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
            if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                int idUser = Convert.ToInt32(queryDatabase.GetIdUser(loginUser));                
                try
                {
                    int amout = Convert.ToInt32(queryDatabase.GetAmountTheory(idUser));
                    queryDatabase.StudentAddAmountTask(idUser, amout + 1);
                }
                catch
                {
                    Debug.Log("Ошибка сверху");
                    queryDatabase.StudentAddAmountTask(idUser, 1);
                }
            }
        }
    }
}
