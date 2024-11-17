using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager
{
    private readonly IAudioService _audioService;

    public GManager(IAudioService audioService)
    {
        _audioService = audioService;
    }

    public void StartGame()
    {
        _audioService.PlaySound();
    }
}