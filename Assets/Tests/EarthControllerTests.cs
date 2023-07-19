using NUnit.Framework;

public class EarthControllerTests
{
    private EarthController _cont;

    [SetUp]
    public void Setup()
    {
        // newing a monobehaviour emits a warning. Extract earth calcs
        _cont = new EarthController();
    }

    [Test]
    public void EarthControllerTestsSimplePasses()
    {
        Assert.AreEqual(1, _cont.one());
    }
}
