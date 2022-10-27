using UnityEngine;

public class BulletPooling : ObjectPooling
{
    public static BulletPooling Instance;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        if (Instance == null)
        {
            base.Start();
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiples Bullet pooling");
            Destroy(this);
        }
    }
    
}
