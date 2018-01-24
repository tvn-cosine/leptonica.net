using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leptonica.Tests
{
    [TestClass()]
    public class PixTests
    {
        private const string file = "Test.png";

        [TestMethod()]
        public void ReadTest()
        {
            Pix pix = Pix.Read(file);

            Assert.AreEqual(1421, pix.Width);
            Assert.AreEqual(1949, pix.Height);
            Assert.AreEqual(ImageFileFormatTypes.IFF_PNG, pix.InputFormat);
            Assert.AreEqual(96, pix.XRes);
            Assert.AreEqual(96, pix.YRes);
        }
    }
}