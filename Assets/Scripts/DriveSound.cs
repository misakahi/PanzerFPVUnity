using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveSound : MonoBehaviour
{
    AudioSource audioSource;
    float volume0 = 0f;  // volume set by inspector

    [Range(0, 1)]
    public float MaxVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.volume0 = this.audioSource.volume;

        EventBus.Instance.Subscribe(OnController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnController(float leftLevel, float rightLevel)
    {
        // in [0, 1]
        float level = Mathf.Max(Mathf.Abs(leftLevel), Mathf.Abs(rightLevel));   

        this.audioSource.volume = MaxVolume * (volume0 + (1-volume0) * level);
    }
}
