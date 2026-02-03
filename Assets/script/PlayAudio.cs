using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class PlayAudio : MonoBehaviour
{
   public float fadeTimeInSeconds;

   private AudioSource audio;

   private void Start()
   {
    audio = GetComponent<AudioSource>();
   }

   private void OnTriggerEnter(Collider other)//if player touch collider, trigger audio
   {
    if(other.tag == "Player")
    {
        //stop all current fade
       StopAllCoroutines();
       StartCoroutine(FadeAudio(true));
    }
   }

   private void OnTriggerExit(Collider other)//if player leave collider, audio stop
   {
    if(other.tag == "Player")
    {
        StopAllCoroutines();
        StartCoroutine(FadeAudioOut());
    }
   }

   private IEnumerator FadeAudio(bool fadeIn)
   {
    float timer = 0;
    float start = fadeIn ? 0 : 1;
    float end = fadeIn ? 1: 0;
   
    if(fadeIn) audio.Play();
    while(timer < fadeTimeInSeconds)
    {
        audio.volume = Mathf.Lerp(0, 1, timer / fadeTimeInSeconds);
        //timer divided by fade time.0:timer 1:fade time
        //i.e. if fadeTime is 2s, and timer is 1s, 1/2=0.5(50% towards 2s)
        timer += Time.deltaTime;
        yield return null;
    }
    audio.volume = end;
    if(!fadeIn) audio.Pause();
   }

   private IEnumerator FadeAudioOut()
   {
    float timer = 0;

    while(timer < fadeTimeInSeconds)
    {
        audio.volume = Mathf.Lerp(1, 0, timer / fadeTimeInSeconds);
        //timer divided by fade time.0:timer 1:fade time
        timer += Time.deltaTime;
        yield return null;
    }
    audio.volume = 0;
    audio.Pause();
   }
}
