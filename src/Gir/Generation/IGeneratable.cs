using System;
using System.Text;

namespace Gir
{
	// Top level generation capability
	public interface IGeneratable
	{
		string Name { get; }
		//void Process();
		void Generate(GenerationOptions opts);
	}

	// When generated as part of another generatable
	public interface IMemberGeneratable
	{
		void Generate(IGeneratable parent, IndentWriter writer);
	}
}
