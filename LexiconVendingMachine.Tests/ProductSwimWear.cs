using LexiconVendingMachine.Models.Products;
using System;
using Xunit;

namespace LexiconVendingMachine.Tests
{
    public class ProductSwimWear
    {
        [Fact]
        public void SwimWearCanOnlyBeCreatedWithAllFieldsAssigned()
        {
            string description = "Blue shorts";
            string emptyDescription = "";
            int price = 100;
            string usage = "Unpack and put on";
            string size = "XL";
            string emptySize = "";
            string type = "Fast drying";

            ArgumentException resultIfDescriptionIsEmpty = Assert.Throws<ArgumentException>(
                () => new SwimWear(emptyDescription, price, usage, size, type));

            string emptyDecriptionError = "Description cant be null or empty.";

            ArgumentException resultIfSizeIsEmpty = Assert.Throws<ArgumentException>(
                () => new SwimWear(description, price, usage, emptySize, type));

            string emptySizeError = "Size cant be null or empty.";

            SwimWear swimWear = new SwimWear(description, price, usage, size, type);

            Assert.Equal(emptyDecriptionError, resultIfDescriptionIsEmpty.Message);
            Assert.Equal(emptySizeError, resultIfSizeIsEmpty.Message);
            Assert.NotNull(swimWear);
            Assert.Equal(description, swimWear.Description);
            Assert.Equal(size, swimWear.Size);
        }

        [Fact]
        public void SwimWearMethodExaminShouldReturnCorrectOverrideExamine()
        {
            string description = "Blue shorts";
            int price = 100;
            string usage = "Unpack and put on";
            string size = "XL";
            string type = "Fast drying";

            string resultFromExamine = $"Info: {description} Price: {price} Size: {size} Type: {type}";

            SwimWear swimWear = new SwimWear(description, price, usage, size, type);

            Assert.Equal(resultFromExamine, swimWear.Examine());
        }
    }
}
