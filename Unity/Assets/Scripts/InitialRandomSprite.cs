using UnityEngine;

public class InitialRandomSprite : MonoBehaviour
{
    public Sprite[] Sprites = new Sprite[0];

	// Use this for initialization
	void Start () {
	    if (this.Sprites.Length == 0)
	    {
	        return;
	    }

	    var spriteRenderer = GetComponent<SpriteRenderer>();

	    var index = Random.Range(0, Sprites.Length);

	    spriteRenderer.sprite = Sprites[index];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
