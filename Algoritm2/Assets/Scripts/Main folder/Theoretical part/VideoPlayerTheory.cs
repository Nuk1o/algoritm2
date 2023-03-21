using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerTheory : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _videoPlayer.frameCount;
        _slider.value = 0;
    }

    private void Update()
    {
        SlideVideo();
        StartBtnVideo();
        StartPauseVideo();
    }

    private void StartPauseVideo()
    {
        if (Input.GetButtonDown("Jump")&&_videoPlayer.isPaused)
        {
            _videoPlayer.Play();
        }
        if (Input.GetButtonDown("Jump")&&_videoPlayer.isPlaying)
        {
            _videoPlayer.Pause();
        }
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
