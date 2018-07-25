using NUnit.Framework;

namespace Gir.Tests.Gtk2.Atk
{
	[TestFixture]
	class AtkTests : GenerationTestBase
	{
		[Test]
		public void GenerateAtkAction ()
		{
			var result = GenerateType (Gtk2Atk1, "Action", true);

			Assert.AreEqual (@"using System;

namespace Atk
{
	public interface Action
	{
		bool DoAction (int i);

		string GetDescription (int i);

		string GetKeybinding (int i);

		string GetLocalizedName (int i);

		int GetNActions ();

		string GetName (int i);

		bool SetDescription (int i, string desc);
	}
}
", result);
		}
	}
}
