using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip WALK, JUMP, LAND;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        WALK = Resources.Load<AudioClip> ("WALK");
        LAND = Resources.Load<AudioClip> ("LAND");
        JUMP = Resources.Load<AudioClip> ("JUMP");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) 
        {
            case "WALK":
            audioSrc.PlayOneShot(WALK);
            audioSrc.loop = true;
            break;

            case "LAND":
            audioSrc.PlayOneShot(LAND);
            break;

            case "JUMP":
            audioSrc.PlayOneShot(JUMP);
            break;
        }
    }
}
