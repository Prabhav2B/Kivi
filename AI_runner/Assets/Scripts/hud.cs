using UnityEngine;
using UnityEngine.UI;

public class hud : MonoBehaviour {

	public static int deaths = 0;
	public static int finished = 0;
	public static int collection_total = 0;
	public int collection = 0;

	public Transform player;
	public Text score_text;
	public Text Collectible;

	public Text Stat_text;

	void FixedUpdate()
	{
		Stat_text.text = (deaths).ToString("0") + "  Deaths Occurred\n";
		Stat_text.text += (finished).ToString("0") + "  Times Finished";

		Collectible.text = (collection).ToString("0")+ "  This Run\n" ;
		Collectible.text += (collection_total).ToString("0") + "  Total";

		score_text.text = player.position.z.ToString("0");
	}

	public void Collected()
	{
		collection_total++;
		collection++;
	}

	public void deathIncrement()
	{
		deaths++;
	}

	public void finishedIncrement()
	{
		finished++;
	}
}
