using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;

/// <summary>
/// Instantiate and initialize necessary objects.
/// </summary>
public class ApplicationController : SingletonMono<ApplicationController>
{

    [RuntimeInitializeOnLoadMethod]
    static void OnInit()
    {
        Instance.Init();
    }

    #region public
    public void Init()
    {
        //Subscribe to input (not need to dispose, this is singleton)
        InputController.Instance.MouseLeftDown.Subscribe(b => HandleMouseDown(b));
    }
    #endregion

    #region Private
    
    private void HandleMouseDown(bool down)
    {
        if (down)
        {
            
            Vector3? worldHitPoint = ScreenPointRaycast(Input.mousePosition)?.point ?? null;
            
            if (worldHitPoint.HasValue)
                InstantiateLightning(worldHitPoint.Value);
        }
    }

    private void InstantiateLightning(Vector3 worldPoint)
    {
        Debug.DrawRay(worldPoint, Vector3.up * 10f, Color.blue, 1f);
        LightningBolt lightningBolt = Instantiate<LightningBolt>(Resources.Load<LightningBolt>("LightningBolt"));
        AudioController.Instance.PlaySoundEffect("Thunder", 1f, Random.Range(0.9f, 1.1f));
        lightningBolt.transform.position = worldPoint;

        //Get inflicted character from radius and set them to PANIC!:
        GetOverlappingCharacters(worldPoint, 10f).ForEach(character => character.SetEmotionalState(FSMCharacter.EmotionalState.Panic, worldPoint, 5f));        
    }

    private List<FSMCharacter> GetOverlappingCharacters(Vector3 position, float radius)
    {
        Collider[] colliders = new Collider[50];
        int count = Physics.OverlapSphereNonAlloc(position, radius, colliders);

        List<FSMCharacter> characters = new List<FSMCharacter>();
        for (int i = 0; i < count; i++)
        {
            FSMCharacter character = colliders[i].GetComponent<FSMCharacter>();
            if (character != null)
                characters.Add(character);
        }

        return characters;
    }

    private RaycastHit? ScreenPointRaycast(Vector3 screenPoint)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit;
        else
            return null;
    }
    #endregion
}