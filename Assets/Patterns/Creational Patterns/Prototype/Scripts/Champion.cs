using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class Champion : MonoBehaviour, ICloneable<Champion>
{
    [Header("BaseStats")] [SerializeField] private float damage = 5;
    [SerializeField] private float maxHealth = 20;

    [Header("Runtime")] private float currentHealth;

    [Header("Modifiers")] private float outgoingDamageIncreaseModifier = 1;
    private float incomingDamageIncreaseModifier = 1;

    public bool IsCLone { get; private set; }

    [SerializeField] private Item[] items = new Item[6];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        items[0] = new MantaStyle();
    }

    public void TakeDamage(float incomingDamage)
    {
        currentHealth -= incomingDamage * incomingDamageIncreaseModifier;
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
    }

    public void DealDamage(Champion target)
    {
        target.TakeDamage(damage * outgoingDamageIncreaseModifier);
    }

    public void UseItem(int itemIndex)
    {
        if (itemIndex >= 0 && itemIndex < items.Length - 1)
        {
            items[itemIndex].Use(this);
        }
    }

    public void ApplyDamageModifiers(float outgoingMultiplier, float incomingMultiplier)
    {
        outgoingDamageIncreaseModifier = outgoingMultiplier;
        incomingDamageIncreaseModifier = incomingMultiplier;
    }

    public Champion Clone()
    {
        var clone = Instantiate(this);
        clone.InitializeCloneFrom(this);
        return clone;
    }

    public void ApplyModifier(IChampionModifier modifier)
    {
        modifier.Apply(this);
    }

    protected virtual void InitializeCloneFrom(Champion original)
    {
        IsCLone = true;
        currentHealth = maxHealth;
        outgoingDamageIncreaseModifier = 1f;
        incomingDamageIncreaseModifier = 1f;

        // ClearRuntimeState();
    }

    private void ClearRuntimeState()
    {
        // Clear status effects cooldowns and whatnot
    }

    public void ApplyCloneVisuals()
    {
        StartCoroutine(LoadCloneAsset());
    }

    private IEnumerator LoadCloneAsset()
    {
        var handle = Addressables.LoadAssetAsync<Material>("CloneMaterial");
        yield return handle;
        GetComponent<MeshRenderer>().material = handle.Result;
    }
}