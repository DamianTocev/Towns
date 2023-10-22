using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownsTests
{
    public class TownsCollectionTests
    {
        [Test]
        public void Test_Constructor_EmptyConstructor()
        {
            var townCollection = new TownsCollection();
            Assert.That(townCollection.Towns.Count, Is.EqualTo(0));
            Assert.That(townCollection.ToString(), Is.Empty);
        }

        [Test]
        public void Test_Constructor_Single_Town()
        {
            var townCollection = new TownsCollection("Sofiq");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townCollection.ToString(), Is.EqualTo("Sofiq"));
        }

        [Test]
        public void Test_Constructor_Two_Towns()
        {
            var townCollection = new TownsCollection("Sofiq, Varna");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townCollection.ToString(), Is.EqualTo("Sofiq, Varna"));
        }

        [Test]
        public void Test_Constructor_ADD_Town()
        {
            var townCollection = new TownsCollection("Sofiq, Varna");
            townCollection.Add("Burgas");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(3));
            Assert.That(townCollection.ToString(), Is.EqualTo("Sofiq, Varna, Burgas"));
        }

        [Test]
        public void Test_Constructor_ADD_Town_Bool()
        {
            var townCollection = new TownsCollection("Sofiq, Varna");
            var isAdded = townCollection.Add("Burgas");
            Assert.True(isAdded);
        }

        [Test]
        public void Test_Add_Duplicate_Town_Alternative()
        {
            var townCollection = new TownsCollection("Sofiq, Varna");
            var isAdded = townCollection.Add("Varna");
            Assert.False(isAdded);
        }
     
        [Test]
        public void Test_Constructor_RemuveAdd_Towns()
        {
            var townCollection = new TownsCollection("Sofiq, Varna, Burgas");
            townCollection.RemoveAt(1);
            Assert.That(townCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townCollection.ToString(), Is.EqualTo("Sofiq, Burgas"));
        }
                
        [Test]
        public void Test_RemoveAtIndex_InvalidIndex()
        {
            var townCollection = new TownsCollection("Sofiq, Varna, Burgas");
            Assert.That(() => townCollection.RemoveAt(3), Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_RemoveAtIndex_InvalidIndex_ArgumentException()
        {
            var townCollection = new TownsCollection("Sofiq, Varna, Burgas");
            Assert.That(() => townCollection.RemoveAt(3), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void Test_Reverse_SingleTown()
        {
            var townCollection = new TownsCollection("Sofiq");
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Reverse_SingleTown_InvalidOperationException()
        {
            var townCollection = new TownsCollection("Sofiq");
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<InvalidOperationException>());
        }

        //////////////////////////////////////

        [Test]
        public void Test_Town_Empty()
        {
            //Arrenge & Act
            var coll = new TownsCollection();

            // Assert
            Assert.That(coll.Towns.Count, Is.EqualTo(0));
            Assert.That(coll.ToString(), Is.Empty);
        }

        [Test]
        public void Test_Town_One()
        {
            //Arrenge & Act
            var coll = new TownsCollection("Varna");

            // Assert
            Assert.That(coll.Towns.Count, Is.EqualTo(1));
            Assert.AreEqual(coll.ToString(), "Varna");
        }

        [Test]
        public void Test_Town_Two()
        {
            //Arrenge & Act
            var coll = new TownsCollection("Varna, Burgas");

            // Assert
            Assert.That(coll.Towns.Count, Is.EqualTo(2));
            Assert.AreEqual(coll.ToString(), "Varna, Burgas");
        }

        [Test]
        public void Test_Town_Add_New()
        {
            //Arrenge 
            var coll = new TownsCollection("Varna");

            // Act
            coll.Add("Gabrovo");

            // Assert
            Assert.That(coll.Towns.Count, Is.EqualTo(2));
            Assert.AreEqual(coll.ToString(), "Varna, Gabrovo");
        }

        [Test]
        public void Test_Town_Reverse_One_Try()
        {
            var coll = new TownsCollection("Varna");
            Assert.That(() => coll.Reverse(), Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Town_RemoveAt_Try()
        {
            var coll = new TownsCollection("Varna, Burgas");
            Assert.That(() => coll.RemoveAt(2), Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Town_Add_Try()
        {
            var coll = new TownsCollection("Varna, Burgas");
            Assert.That(() => coll.Add(), Throws.InstanceOf<NotImplementedException>());
        }

    }
}
