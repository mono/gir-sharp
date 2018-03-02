using System.Collections.Generic;

namespace Gir
{
	// Top level generation capability
	public interface IGeneratable
	{
		string Name { get; }
		//void Process();
		void Generate (GenerationOptions opts);
	}

	// IDocumented might end up being added to IGeneratable/IMemberGeneratable
	public interface IDocumented
	{
		Documentation Doc { get; }
	}

	// When generated as part of another generatable
	public interface IMemberGeneratable
	{
		string Name { get; }
		bool NewlineAfterGeneration (GenerationOptions opts);
		void Generate (IGeneratable parent, IndentWriter writer);
	}

	public interface ICallable : IMemberGeneratable, IDocumented
	{
		bool IsInstanceCallable (IGeneratable parent, GenerationOptions opts);
		string GetModifiers (IGeneratable parent, GenerationOptions opts);

		string CIdentifier { get; }
		ReturnValue ReturnValue { get; }
		List<Parameter> Parameters { get; }
	}
}
