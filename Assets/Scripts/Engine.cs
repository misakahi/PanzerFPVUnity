using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.AudioSource = GetComponent<AudioSource>();
        this.AudioSource.volume = 0.5f;

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

        this.AudioSource.volume = 0.5f + level / 2;
    }
}
