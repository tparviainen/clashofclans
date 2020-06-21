using ClashOfClans.Extensions;
using ClashOfClans.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ClashOfClans.Models
{
    internal class NullableTypes
    {
        public Role? NullableRole { get; set; }
        public Player? NullablePlayer { get; set; }
        public int? NullableTrophies { get; set; }
    }

    internal class NonnullableTypes
    {
        private Role? _nonnullableRole;
        private int? _nonnullableTrophies;

        public Role NonnullableRole { get => _nonnullableRole ?? default; set => _nonnullableRole = value; }
        public Player NonnullablePlayer { get; set; } = default!;
        public int NonnullableTrophies { get => _nonnullableTrophies ?? default; set => _nonnullableTrophies = value; }
    }
}

namespace ClashOfClans.Tests.Unit
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void NullPropertiesFoundFromNullableObject()
        {
            // Arrange
            var nullableTypes = new NullableTypes();

            // Act
            var nullProperties = nullableTypes.GetNullMembers();

            // Assert
            Assert.AreEqual(3, nullProperties.Count());
        }

        [TestMethod]
        public void NullPropertiesFoundFromNonnullableObject()
        {
            // Arrange
            var nonnullableTypes = new NonnullableTypes();

            // Act
            var nullProperties = nonnullableTypes.GetNullMembers();

            // Assert
            Assert.AreEqual(3, nullProperties.Count());
        }
    }
}
