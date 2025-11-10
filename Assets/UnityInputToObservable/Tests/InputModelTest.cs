using System;
using System.ComponentModel;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityInputToObservable.Configs;
using UnityInputToObservable.Utils;

namespace UnityInputToObservable.Tests
{
    [TestFixture]
    public class InputModelTest
    {
        private const string InvalidPlayerMapName = "MockAction";
        private Mock<IPlayerInputConfig> _mockConfig;
        private InputActionAsset _asset;

        [SetUp]
        public void Setup()
        {
            _asset = ScriptableObject.CreateInstance<InputActionAsset>();

            _mockConfig = new Mock<IPlayerInputConfig>();
            _mockConfig.Setup(p => p.PlayerInputActionAsset).Returns(_asset);
        }

        [Test]
        public void Constructor_ThrowsArgumentException_WhenMapNotFoundInAsset()
        {
            _asset.AddActionMap(InvalidPlayerMapName);
            Assert.Throws<ArgumentException>(() =>
            {
                var model = new InputModel<MockActionMap, MockActionType>(MockActionMap.PlayerMap, _mockConfig.Object);
            });
        }

        [Test]
        public void Constructor_ThrowsArgumentException_WhenAssetNotAssigned()
        {
            _mockConfig.Setup(p => p.PlayerInputActionAsset).Returns(() => null);
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                var model = new InputModel<MockActionMap, MockActionType>(MockActionMap.PlayerMap, _mockConfig.Object);
            });
        }

        [Test]
        public void Constructor_ThrowsArgumentException_WhenMapTypeHasNoRepresentation()
        {
            _asset.AddActionMap(InvalidPlayerMapName);
            Assert.Throws<InvalidEnumArgumentException>(() =>
            {
                var model = new InputModel<MockActionMap, MockActionType>(MockActionMap.NoRepresentationMap,
                    _mockConfig.Object);
            });
        }
    }

    public enum MockActionMap
    {
        [InputItemStringRepresentation("PlayerMap")]
        PlayerMap,
        NoRepresentationMap
    }

    public enum MockActionType
    {
        [InputItemStringRepresentation("MockAction")]
        MockAction
    }
}