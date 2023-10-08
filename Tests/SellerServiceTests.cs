using Moq;
using SalesWeb.Domain.Interfaces.Repositories;
using SalesWeb.Domain.Services;
using SalesWeb.Domain.Services.Exceptions;
using SalesWeb.Models;
using SalesWeb.Models.InputModel;
using Shouldly;
using System;
using Xunit;

namespace Tests
{
    public class SellerServiceTests
    {
        [Fact]
        public async void ValidSeller_InsertIsCalled_ReturnValidSellerViewModel()
        {
            //Arrange
            var department = new Department
            {
                Id = 1,
                Name = "Eletronics"
            };

            const string birthDateString = "5/8/1900 12:00:00 AM";
            
            var birthDate = DateTime.Parse(birthDateString, System.Globalization.CultureInfo.InvariantCulture);

            var sellerDto = new AddSellerInputModel
            (
                "Renata",
                "test@test.com",
                birthDate,
                5000,
                department
            );

            var seller = new Seller
            (
                1,
                "Renata",
                "test@test.com",
                birthDate,
                5000,
                department
            );

            var sellerRepositoryMock = new Mock<ISellerRepository>();

            sellerRepositoryMock.Setup(w => w.InsertAsync(It.IsAny<AddSellerInputModel>())).ReturnsAsync(seller);

            var sellerService = new SellerService(sellerRepositoryMock.Object);

            //Act
            var result = await sellerService.InsertAsync(sellerDto);

            //Assert
            result.Name.ShouldBe(sellerDto.Name);
            result.Email.ShouldBe(sellerDto.Email);
            result.BirthDate.ShouldBe(sellerDto.BirthDate);
            result.BaseSalary.ShouldBe(sellerDto.BaseSalary);
            result.Department.ShouldBe(sellerDto.Department);

            sellerRepositoryMock.Verify(sr => sr.InsertAsync(It.IsAny<AddSellerInputModel>()), Times.Once());
        }

        [Fact]
        public void InvaliBirthDateForSeller_ConstructosIsCalled_ThrowAnInvalidBirthDateException()
        {
            //Arrange
            var department = new Department
            {
                Id = 1,
                Name = "Eletronics"
            };

            const string birthDateStringInFuture = "5/8/2050 12:00:00 AM";
            
            var birthDate = DateTime.Parse(birthDateStringInFuture, System.Globalization.CultureInfo.InvariantCulture);

            var exception = Assert.Throws<BirthDateCannotBeInTheFutureException>(() =>
                new AddSellerInputModel
                (
                    "Renata",
                    "test@test.com",
                    birthDate,
                    5000,
                    department
                ));

            Assert.Equal("Birth Date cannot be in the future.", exception.Message);
        }

        [Fact]
        public async void SellerIdWithNoSales_RemoveIsCalled_SellerIsRemoved()
        {
            //Arrange
            const string birthDateString = "5/8/1900 12:00:00 AM";

            var birthDate = DateTime.Parse(birthDateString, System.Globalization.CultureInfo.InvariantCulture);

            var department = new Department(1, "Eletronics");

            var seller = new Seller(1, "Renata", "test@test.com", birthDate, 5000, department);

            var sellerRepositoryMock = new Mock<ISellerRepository>();

            sellerRepositoryMock.Setup(sr => sr.RemoveAsync(It.IsAny<int>()));
            
            var sellerService = new SellerService(sellerRepositoryMock.Object);

            //Act
            await sellerService.RemoveAsync(seller.Id);
        
            //Assert
            sellerRepositoryMock.Verify(sr => sr.RemoveAsync(It.IsAny<int>()), Times.Once());
            
        }
    }
}