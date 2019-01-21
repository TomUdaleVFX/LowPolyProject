using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CollectiblesData {

	public string collectibleName;
	public int collectibleNum;
    public Text countText;

    public string collectibleDesc;
    public Sprite collectibleImage;

    void Update()
    {
        countText.text = collectibleNum.ToString("00");
    }

    public void CollectiblesCount()
    {
        countText.text = collectibleNum.ToString();
    }

}
