using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    public void StartSequence()
    {
        _playableDirector.Play();
    }
}
