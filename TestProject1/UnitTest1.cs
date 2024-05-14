using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestProject1
{
    public class UnitTest1
    {
      //Boolean Assert
            [Fact]
            public void Test_IsStopped_NegativeVelocity()
            {
            // Arrange
               Toyota toyota = new Toyota();
                toyota.velocity = -10; 

                // Act
                bool actualResult = toyota.IsStopped();

                // Assert
                Assert.False(actualResult);
            }
        //Numeric Assert
        [Fact]
        public void Accelerate_velocity10_Range10to20()
        {
            // Arrange
            Toyota toyota = new Toyota() { velocity = 10 };
            BMW bMW = new BMW() { velocity = 10 };

            // Act
            toyota.Accelerate();
            bMW.Accelerate();

            // Numeric Assert
            double tolerance = 5.0;  
            Assert.InRange(toyota.velocity, 15 - tolerance, 25 + tolerance);

            Assert.InRange(bMW.velocity, 15 - tolerance, 25 + tolerance);


             Assert.NotInRange(toyota.velocity, 80, 130);

            //Assert.True(toyota.velocity < 15);
        }
        //String assert 
        [Fact]
        public void GetDirection_DirectionBackword_Backorward()
        {
            // Arrange
           Toyota toyota = new Toyota() { drivingMode = DrivingMode.Backward };

            // Act
           string result = toyota.GetDirection();

           // String Assert
            Assert.Equal("Backward", result);

            Assert.StartsWith("Ba", result);
            Assert.EndsWith("rd", result);

            Assert.Contains("wa", result);
            Assert.DoesNotContain("zx", result);

            Assert.Matches("B[a-z]{6}", result);
            Assert.DoesNotMatch("F[a-z]{8}", result);
        }
        //Reference assert 
        [Fact]
        public void GetMyCar_AskForRefrence_Same()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW t = new BMW();

            // Act
            Car result = bmw.GetMyCar();

            // Reference Assert
            Assert.Same(bmw, result);
            Assert.NotSame(t, result);
        }
        //Type assert 
        [Fact]
        public void NewCar_AskForToyota_ToyotaObject()
        {
            // Arrange

            // Act
            Car? result = CarFactory.NewCar(CarTypes.Toyota);

            // Type Assert
            Assert.IsType<Toyota>(result);
            Assert.IsNotType<BMW>(result);

            Assert.IsAssignableFrom<Car>(result);
        }
        //Collection
        [Fact]
        public void AddCar_AddToyota_ListContainObject()
        {
            // Arrange
            CarStore carStore = new CarStore();
            Toyota toyota = new Toyota() { drivingMode = DrivingMode.Forward };
            BMW bMW = new BMW();

            // Act
            carStore.AddCar(toyota);

            // Collection Asserts
           // Assert.Empty(carStore.cars);
            Assert.NotEmpty(carStore.cars);
        }
        //Exception
        [Fact]
        public void NewCar_AskForHonda_Exception()
        {
            // Arrange
            // Exception Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
            Assert.ThrowsAny<Exception>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });

        }









    }
}
