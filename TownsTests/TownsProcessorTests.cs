using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]
        public void Test_ExecuteCommand_InvalidOperation()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var actual = townProcessor.ExecuteCommand("alabala");

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid command: alabala"));
        }

        [Test]
        public void Test_ExecuteCommand_CreateCommand()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            var actual = townProcessor.ExecuteCommand(createCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_PrintCommand()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var printCommand = "PRINT";
            var actual = townProcessor.ExecuteCommand(printCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Towns: "));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_ExecuteCommand_PrintCommand_Alternative()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var printCommand = "PRINT";
            var actual = townProcessor.ExecuteCommand(printCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Towns: Paris, London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_AddCommand()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommand = "ADD Pargue";
            var actual = townProcessor.ExecuteCommand(addCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully added: Pargue"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_ExecuteCommand_AddCommand_DuplicateTown()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommand = "ADD Paris";
            var actual = townProcessor.ExecuteCommand(addCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Cannot add: Paris"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_RemoveCommand_ValidIndex()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var removeCommand = "REMOVE 0";
            var actual = townProcessor.ExecuteCommand(removeCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully removed from index: 0"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_ExecuteCommand_TryRemoveCommand_InValidIndex()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var removeCommand = "REMOVE 5";
            var actual = townProcessor.ExecuteCommand(removeCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid operation."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_ReverseCommand()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var reverseCommand = "REVERSE";
            var actual = townProcessor.ExecuteCommand(reverseCommand);

            var printCommand = "PRINT";
            var actualPrint = townProcessor.ExecuteCommand(printCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Collection of towns reversed."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
            Assert.That(actualPrint, Is.EqualTo("Towns: London, Paris"));
        }

        [Test]
        public void Test_ExecuteCommand_ReverseCommand_OneTown()
        {
            //Arrange
            var townProcessor = new TownsProcessor();

            //Act
            var createCommand = "CREATE Paris";
            townProcessor.ExecuteCommand(createCommand);

            var reverseCommand = "REVERSE";
            var actual = townProcessor.ExecuteCommand(reverseCommand);

            var printCommand = "PRINT";
            var actualPrint = townProcessor.ExecuteCommand(printCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Cannot reverse a collection of towns with less than 2 items."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(1));
            Assert.That(actualPrint, Is.EqualTo("Towns: Paris"));
        }   

    }
}
