using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioTrigger
{
    [SerializeField] AudioMixerGroup mixer;
    [SerializeField] string[] soundName = default;
    [SerializeField] [Range(0, 1)] float volume = 1f;
    [SerializeField] float range = 30f;
    [SerializeField] [Range(0, 1)] float stereo = 1f;
    [SerializeField] float minPitch = 0.95f;
    [SerializeField] float maxPitch = 1.05f;
    [SerializeField] bool loop;

    AudioSource audioSource;
    GameObject newSource;
    bool stopped;

    public void Play(Vector3 position)
    {
        if (soundName.Length == 0) return;

        if(Transform.FindObjectOfType<Player>() != null)
            if (Vector3.Distance(position, Player.instance.transform.position) > range) return;

        newSource = new GameObject();
        audioSource = newSource.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.minDistance = 1f;
        audioSource.maxDistance = range;
        audioSource.spatialBlend = stereo;
        audioSource.pitch = minPitch + Random.value * (maxPitch - minPitch);
        audioSource.clip = AudioManager.GetSound(soundName[Random.Range(0, soundName.Length)]);

        audioSource.Play();
        MonoBehaviour.Destroy(newSource, audioSource.clip.length + 0.5f);


    }

    public void Stop()
    {
        audioSource.Stop();
        //MonoBehaviour.Destroy(audioSource);
    }
}
