using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Champion : MonoBehaviour, ICloneable<Champion>
{
    [SerializeField] private float damage = 5;
    [SerializeField] private float health = 20;
    private float outgoingDamageIncreaseModifier = 1;
    private float incomingDamageIncreaseModifier = 1;
    [SerializeField] private Item[] items = new Item[6];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        items[0] = new MantaStyle();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float incomingDamage)
    {
        health -= incomingDamage * incomingDamageIncreaseModifier;
    }

    public void Heal(float heal)
    {
        health += heal;
    }

    public void DealDamage(Champion target)
    {
        target.TakeDamage(damage * outgoingDamageIncreaseModifier);
    }

    public Champion Clone(int cloneAmount, float outgoingDamageIncrease, float incomingDamageIncrease)
    {
        var clone = Instantiate(this);
        clone.outgoingDamageIncreaseModifier = outgoingDamageIncrease;
        clone.incomingDamageIncreaseModifier = incomingDamageIncrease;
        StartCoroutine(LoadCloneAsset(clone));
        return clone;
    }

    private IEnumerator LoadCloneAsset(Champion clone)
    {
        var handle = Addressables.LoadAssetAsync<Material>("CloneMaterial");
        yield return handle;
        clone.gameObject.GetComponent<MeshRenderer>().material = handle.Result;
    }
}