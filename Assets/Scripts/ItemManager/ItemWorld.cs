using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform= Instantiate(ItemAsset.instance.pfItemWorld,position,Quaternion.identity);
        ItemWorld itemWorld=transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    private void Awake()
    {
      spriteRenderer= GetComponent<SpriteRenderer>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
