using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineControl : MonoBehaviour
{
    //public TimeControlPlayable timeline;
    public PlayableDirector timeline;
    public GameObject discSlots;
    public GameObject skipIntroButton;

    /// <summary>
    /// Skips the game's introduction
    /// </summary>
    [ContextMenu("Skip Intro")]
    public void SkipIntro() {
        timeline.time = timeline.duration;
        timeline.Evaluate();
        GameManager.GetInstance().TriggerGameStart();
        discSlots.SetActive(true);
        skipIntroButton.SetActive(false);
        timeline.Stop();
    }

}
