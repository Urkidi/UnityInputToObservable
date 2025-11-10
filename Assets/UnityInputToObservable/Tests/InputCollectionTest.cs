using Moq;
using NUnit.Framework;
using UnityInputToObservable.Utils;

namespace UnityInputToObservable.Tests
{
    [TestFixture]
    public class InputCollectionTest
    {
        private Mock<IInputModelFactory<MockActionMap, MockActionType>> _mockFactory;
        private Mock<IInputModelFactory<MockEmptyActionMap, MockActionType>> _mockEmptyFactory;

        [SetUp]
        public void Setup()
        {
            _mockFactory = new Mock<IInputModelFactory<MockActionMap, MockActionType>>(MockBehavior.Strict);
            _mockEmptyFactory = new Mock<IInputModelFactory<MockEmptyActionMap, MockActionType>>(MockBehavior.Strict);

            _mockFactory.Setup(factory => factory.Create(It.IsAny<MockActionMap>())).Returns(() => null).Verifiable();
            _mockEmptyFactory.Setup(factory => factory.Create(It.IsAny<MockEmptyActionMap>())).Returns(() => null).Verifiable();
        }

        [Test]
        public void Constructor_WhenActionMapEmpty_ThrowsException()
        {
            var collectionModel =
                new InputCollectionModel<MockEmptyActionMap, MockActionType>(_mockEmptyFactory.Object);
            _mockEmptyFactory.Verify(factory => factory.Create(It.IsAny<MockEmptyActionMap>()), Times.Never());
        }

        [Test]
        public void Constructor_WhenActionMapNotEmpty_CreatesInputModels()
        {
            var collectionModel = new InputCollectionModel<MockActionMap, MockActionType>(_mockFactory.Object);
            _mockFactory.Verify(factory => factory.Create(It.IsAny<MockActionMap>()), Times.Exactly(3));
        }

        public enum MockActionMap
        {
            [InputItemStringRepresentation("PlayerMap")]
            PlayerMap,
            [InputItemStringRepresentation("PlayerMap2")]
            PlayerMap2,
            NoRepresentationMap
        }

        public enum MockEmptyActionMap
        {
        }
    }
}