using System;
using UnityEngine;

public class DifferecePointer : MonoBehaviour
{
    public DifferecePointer BindedDifferencePointer;
    [SerializeField] private GameObject effects;
    private Collider2D myCollider;

    public event Action DifferenceHasFound;

    private void OnMouseDown()
    {
        ActivateDifferencePointer();
        BindedDifferencePointer.ActivateDifferencePointer();
    }

    public void ActivateDifferencePointer()
    {
        myCollider.enabled = false;
        effects.SetActive(true);
        OnDifferenceHasFound();
    }

    private void OnDifferenceHasFound()
    {
        DifferenceHasFound?.Invoke();
    }

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        effects.SetActive(false);
    }
}
