using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelTuner : MonoBehaviour
{
    [SerializeField] private Transform picture;
    [SerializeField] private Transform bindedPicture;
    private LevelManager levelManager;

    void Awake()
    {
        List<DifferecePointer> differecePointers = picture.transform.GetComponentsInChildren<DifferecePointer>().ToList();
        levelManager = GetComponent<LevelManager>();
        levelManager.differecePointers = differecePointers;
        levelManager.InitializeLevel();
        List<DifferecePointer> bindedDifferecePointers = bindedPicture.GetComponentsInChildren<DifferecePointer>().ToList();

        for(int i = 0; i < differecePointers.Count; i++)
        {
            for(int j = 0; j < bindedDifferecePointers.Count; j++)
            {
                if (differecePointers[i].gameObject.name.Equals(bindedDifferecePointers[j].gameObject.name))
                {
                    differecePointers[i].BindedDifferencePointer = bindedDifferecePointers[j];
                    bindedDifferecePointers[j].BindedDifferencePointer = differecePointers[i];
                    bindedDifferecePointers.Remove(bindedDifferecePointers[j]);
                }
            }
        }

        Destroy(this);
    }
}
