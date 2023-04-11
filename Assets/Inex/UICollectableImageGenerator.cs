using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class UICollectableImageGenerator : Singleton<UICollectableImageGenerator>
{
    public int generateCount = 12;
    public float radius = 250f;
    public Image itemPrefab;

    public void SpawnItems(Vector3 spawnPosition, Vector3 destination, Action onItemReachedDestination)
    {
        List<Image> images = new List<Image>();

        for (int i = 0; i < generateCount; i++)
        {
            Image IImage = Instantiate(itemPrefab, MainMenu.instance.transform);
            IImage.transform.position = spawnPosition;
            images.Add(IImage);

            float randomX = UnityEngine.Random.Range(spawnPosition.x - radius, spawnPosition.x + radius);
            float randomY = UnityEngine.Random.Range(spawnPosition.y - radius, spawnPosition.y + radius);

            Vector3 randomPosAroundSpawnPoint = new Vector3(randomX, randomY, spawnPosition.z);

            Sequence sequence = DOTween.Sequence();

            Tween t0 = IImage.transform.DOMove(randomPosAroundSpawnPoint, 0.7f).SetEase(Ease.OutQuint);

            sequence.Append(t0);

            Tween t1 = IImage.transform.DOMove(destination, 0.7f).SetEase(Ease.OutQuint);

            if (i == 0)
            {
                t1.onComplete += () =>
                {
                    onItemReachedDestination?.Invoke();
                };
            }

            t1.onComplete += () =>
            {
                Destroy(IImage.gameObject);
            };

            sequence.Append(t1);
        }
    }

}