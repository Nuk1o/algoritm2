using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerTheory : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Slider _slider;

    private VideoView _videoView;
    public void StartVideo()
    {
        _slider.maxValue = _videoPlayer.frameCount;
        _slider.value = 0;
        _videoView = new VideoView();
    }

    private void Update()
    {
        SlideVideo();
        StartBtnVideo();
        _videoView.VideoViewCheck(_slider,_videoPlayer);
    }
    
    private void SlideVideo()
    {
        _slider.onValueChanged.AddListener(delegate{ SliderValue(); });
    }

    private void SliderValue()
    {
        _videoPlayer.frame = (long)_slider.value;
    }

    private void StartBtnVideo()
    {
        if (_videoPlayer.isPlaying)
        {
            _btnPlay.onClick.AddListener(delegate { _videoPlayer.Pause(); });
        }

        if (_videoPlayer.isPaused)
        {
            _btnPlay.onClick.AddListener(delegate { _videoPlayer.Play(); });
        }
    }
}
