using System.Collections.Generic;
using DataBase;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoView : MonoBehaviour
{
    private BDbase _bDbase;
    private void Start()
    {
        _bDbase = new BDbase();
    }

    public void VideoViewCheck(Slider _slider, VideoPlayer _videoPlayer)
    {
        if (_slider.maxValue == _slider.value || _videoPlayer.length == _videoPlayer.frame)
        {
            _slider.value = 0;
            _videoPlayer.frame = 0;
            Debug.Log("Конец видео");
            SafePlayerPrefs _safePlayerPrefs = new SafePlayerPrefs();
            if (_safePlayerPrefs.HasBeenEdited("first","LoginUser"))
            {
                string loginUser = PlayerPrefs.GetString("LoginUser");
                BDbase _bDbase = new BDbase();
                List<string> _list = _bDbase.get_id_user(loginUser);
                Debug.Log(_list[_list.Count-1]);
            }
            
        }
    }
}
