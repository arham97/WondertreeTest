using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject AnimCoin;
    public Transform targetPosition;
    public Ease eastype;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("CoinCollected");
            AudioManager.instance.CoinSounds();
            Animate(this.transform.position, 1);
            Destroy(this.gameObject);
        }
    }

	void Animate(Vector3 collectedCoinPosition, int amount)
    {

        //extract a coin from the pool
        GameObject coin = Instantiate(AnimCoin);
		//move coin to the collected coin pos
		coin.transform.position = collectedCoinPosition ;

		//animate coin to target position
		float duration =1.5f;
		coin.transform.DOMove(new Vector3(targetPosition.position.x, targetPosition.position.y, 0), duration)
		.SetEase(eastype)
		.OnComplete(() => {
			//executes whenever coin reach target position
			coin.SetActive(false);
            GameManager.instance.coins += 1;
        });
			
		
	}
}
