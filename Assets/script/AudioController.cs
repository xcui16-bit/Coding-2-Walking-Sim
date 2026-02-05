using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]

public class AudioContoller : MonoBehaviour
{
    public float fadeTimeInSeconds = 1;

    public AudioMixerSnapshot mutedSnapshot;
    public AudioMixerSnapshot unmutedSnapshot;
    public float fadeTime;

    private AudioSource audioSource;
    private AudioMixer audioMixer;
    private float[] weights;
    private AudioMixerSnapshot[]snapshots;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioMixer = audioSource.outputAudioMixerGroup.audioMixer;

        snapshots = new AudioMixerSnapshot[]
        {
            unmutedSnapshot,
            mutedSnapshot
        };

        weights = new float[2];
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            weights[0] = 1;
            weights[1] = 0;
            audioMixer.TransitionToSnapshots(snapshots,weights, fadeTime);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            weights[1] = 0;
            weights[0] = 1;
            audioMixer.TransitionToSnapshots(snapshots, weights, fadeTime);
        }
    }
    }