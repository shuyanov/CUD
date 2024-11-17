using UnityEngine;

public interface IAudioService
{
    void PlaySound()
    {
        Debug.Log("Игровое звуковое сопровождение");
    }
}

public class AudioService : IAudioService
{
    public void PlaySound()
    {
        Debug.Log("Playing sound");
    }
}