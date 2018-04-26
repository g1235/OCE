using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeCoreExer.UnitTests
{
    public class Mvm_Tests
    {
        [TestCase("1")]
        [TestCase("")]
        [TestCase("abba")]
        [TestCase("aba")]
        [TestCase("abb")]
        [TestCase("abbah")]
        [TestCase("a bba")]
        public void VM_Fetch10RndItunesSongsCommand(string input)
        {
            Mock<ISongsFetchingService> MockSongsFetchingService = new Mock<ISongsFetchingService>();
            var mvm = new MainViewModel(MockSongsFetchingService.Object);

            mvm.ArtistName = input;

            mvm.Fetch10RndItunesSongsCommand.Execute(null);

            MockSongsFetchingService.Verify(m => m.Fetch10RndSongs(It.IsAny<string>()), Times.Once);
        }





        [Test]
        public void Create_VM()
        {
            Mock<ISongsFetchingService> sfs = new Mock<ISongsFetchingService>();
            var o = sfs.Object.Fetch10RndSongs("abba");
            var mvm = new MainViewModel(sfs.Object);
        }




    }
}
