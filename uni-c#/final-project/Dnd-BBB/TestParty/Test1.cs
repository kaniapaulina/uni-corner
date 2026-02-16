using Dnd_BBB.Classes;
using Dnd_BBB.Core;
using Dnd_BBB.Races;

namespace TestParty
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void UstawienieNazwyPartyTestMethod1()
        {
            // Arrange
            Party party = new Party();
            string nazwa = "Magic nerds";

            // Act
            party.PartyName = nazwa;

            // Assert
            Assert.AreEqual(nazwa, party.PartyName);
        }

        [TestMethod]
        public void InicjalizacjaPartyMembersTestMethod1()
        {
            // Arrange
            Party party;

            // Act
            party = new Party();

            // Assert
            Assert.IsNotNull(party.PartyMembers);
        }


        [TestMethod]
        public void DodanieNowegoPartyMemberTestMethod1()
        {
            // Arrange
            Party party = new Party();

            // Act
            Character partyMember = new Character();
            party.AddMember(partyMember);

            // Assert
            Assert.AreEqual(1, party.PartyMembers.Count);
        }

        [TestMethod]
        public void SprawdzanieCompareToDlaParyMembersPoHpTestMethod1()
        {
            // Arrange
            Party party = new Party();
            UnitRace r1 = new Human();
            UnitClass c1 = new Bard();
            UnitRace r2 = new Dragonborn();
            UnitClass c2 = new Sorcerer();
            // Act
            Character char1 = new Character("Paulina", c1, r1);
            Character char2 = new Character("Wiktoria", c2, r2);
            // Assert
            Assert.AreEqual(1, char1.Hp.CompareTo(char2.Hp));
        }

        [TestMethod]
        public void PoprawnoscKlonowaniaPartyTestMethod1()
        {
            // Arrange
            UnitRace r1 = new Human();
            UnitClass c1 = new Bard();
            Character char1 = new Character("Paulina", c1, r1);
            UnitRace r2 = new Dragonborn();
            UnitClass c2 = new Sorcerer();
            Character char2 = new Character("Wiktoria", c2, r2);
            char2.AddSpell("Ray of Frost");
            Party original = new Party("Magic nerds");
            original.AddMember(char1);
            original.AddMember(char2);

            // Act
            Party clone = original.DeepCopy();

            // Assert
            Assert.AreNotSame(original, clone);
            Assert.AreEqual(original.PartyName, clone.PartyName);

            for (int i = 0; i < original.PartyMembers.Count; i++)
            {
                Character orgChar = original.PartyMembers[i];
                Character cloneChar = clone.PartyMembers[i];

                Assert.AreNotSame(orgChar, cloneChar);
                Assert.AreEqual(orgChar.Name, cloneChar.Name);
                Assert.AreEqual(orgChar.Ac, cloneChar.Ac);
                CollectionAssert.AreEqual(orgChar.Spells, cloneChar.Spells);
            }
        }
    }
}
