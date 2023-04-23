using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectible : MonoBehaviour
{
    public int point = 1;

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (point < 4)
            {
                SoundManager.instance.PlayRandomFromList(SoundManager.instance.dropSounds);
            }
            else
            {
                SoundManager.instance.PlaySfx(SoundManager.instance.superDropCollect);
            }
            PlayerScore.instance.AddPoint(point);
            DOTween.Kill(transform);
            Destroy(gameObject);
        }
    }
}
