using System;
using System.Collections.Generic;
using DataBase;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoView : MonoBehaviour
{
    private BDbase _bDbase;
    private bool _isAdd = false;
    private void Start()
    {
        _bDbase = new BDbase();
    }

    public void VideoViewCheck(Slider _slider, VideoPlayer _videoPlayer)
    {
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
                BDbase _bDbase = new BDbase();
                int idUser = Convert.ToInt32(_bDbase.get_id_user(loginUser));
                try
                {
                    int amout = Convert.ToInt32(_bDbase.get_amount_theory(idUser));
                    _bDbase.student_add_amount_task(idUser, amout+1);
                }
                catch
                {
                    Debug.Log("Ошибка сверху");
                    _bDbase.student_add_amount_task(idUser, 1);
                }
            }
            
        }
    }
}
