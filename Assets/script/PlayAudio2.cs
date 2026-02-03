using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
public class PlayAudio2 : MonoBehaviour
{
    public float fadeTimeInSeconds;
    private AudioSource audio;
    private AudioMixerSnapshot unmutedSnapshot;
    private AudioMixerSnapshot mutedSnapshot;

   private void Start()
   {
    audio = GetComponent<AudioSource>();
   }

   private void OnTriggerEnter(Collider other)//if player touch collider, trigger audio
   {
    if(other.tag == "Player")
    {
       
    }
   }

   private void OnTriggerExit(Collider other)//if player leave collider, audio stop
   {
    if(other.tag == "Player")
    {
    
    
    }
   }
}