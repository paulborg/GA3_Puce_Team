using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public List<PlayableDirector> timelines;    //Reference to timelines, assigned in Inspector.

    public PlayableDirector currentTimeline;   //Currently active timeline.

    private void Start()
    {
        //Assigning first timeline in List index to currentTimeline on game start.
        currentTimeline = timelines[0];
        currentTimeline.Play();
    }

    public void PlayTimeline (int index)
    {
        if (index < 0 || index >= timelines.Count) return;  //Preventing negative indexes and out-of-bounds index errors.

        //Stopping the currently active timeline.

        if (currentTimeline != null)
            Debug.Log("Stopping " + currentTimeline.gameObject.name);
            currentTimeline.Stop();

        //Playing/Switching to the new timeline.

        currentTimeline = timelines[index];
        Debug.Log("Playing " + currentTimeline.gameObject.name);
        currentTimeline.Play();
    }


}
