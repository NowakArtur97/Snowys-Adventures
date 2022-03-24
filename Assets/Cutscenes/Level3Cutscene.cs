using UnityEngine;

public class Level3Cutscene : LevelCutscene
{
    [SerializeField] private ElectricDevice _electricDevice;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        _electricDevice.Interact();

        gameObject.SetActive(false);
    }
}
