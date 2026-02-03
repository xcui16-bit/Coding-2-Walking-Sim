using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class PlayAudio : MonoBehaviour
{
   private AudioSource audio;

   private void Start()
   {
    audio = GetComponent<AudioSource>();
   }

   private void OnTriggerEnter(Collider other)//if player touched collider, trigger audio
   {
    if(other.tag == "Player")
    {
        audio.Play();
        Debug.Log("PlayAudio");
    }
   }
}
