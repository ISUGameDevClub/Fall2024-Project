using NUnit.Framework;
using UnityEngine;

public class CurrencyTests
{
    private Currency currency;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and attach the Currency component to it.
        GameObject gameObject = new GameObject();
        currency = gameObject.AddComponent<Currency>();
    }

    [Test]
    public void AddCurrency_AddsAmountToPlayerCurrency()
    {
        // Arrange
        int initialCurrency = currency.GetCurrency();
        int amountToAdd = 10;

        // Act
        currency.AddCurrency(amountToAdd);

        // Assert
        Assert.AreEqual(initialCurrency + amountToAdd, currency.GetCurrency());
    }

    [Test]
    public void RemoveCurrency_RemovesAmountIfEnoughCurrency()
    {
        // Arrange
        currency.SetCurrency(20);
        int amountToRemove = 10;

        // Act
        bool result = currency.RemoveCurrency(amountToRemove);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(10, currency.GetCurrency());
    }

    [Test]
    public void RemoveCurrency_FailsIfNotEnoughCurrency()
    {
        // Arrange
        currency.SetCurrency(5);
        int amountToRemove = 10;

        // Act
        bool result = currency.RemoveCurrency(amountToRemove);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(5, currency.GetCurrency());
    }

    [Test]
    public void SetCurrency_SetsPositiveAmount()
    {
        // Arrange
        int amountToSet = 30;

        // Act
        bool result = currency.SetCurrency(amountToSet);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(amountToSet, currency.GetCurrency());
    }

    [Test]
    public void SetCurrency_FailsIfAmountIsNegative()
    {
        // Arrange
        int amountToSet = -10;

        // Act
        bool result = currency.SetCurrency(amountToSet);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CanDeductCurrency_ReturnsTrueIfEnoughCurrency()
    {
        // Arrange
        currency.SetCurrency(20);
        int amountToDeduct = 10;

        // Act
        bool result = currency.CanDeductCurrency(amountToDeduct);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CanDeductCurrency_ReturnsFalseIfNotEnoughCurrency()
    {
        // Arrange
        currency.SetCurrency(5);
        int amountToDeduct = 10;

        // Act
        bool result = currency.CanDeductCurrency(amountToDeduct);

        // Assert
        Assert.IsFalse(result);
    }
}