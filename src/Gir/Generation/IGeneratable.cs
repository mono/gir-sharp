using System;
using System.Collections.Generic;
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

	// IDocumented might end up being added to IGeneratable/IMemberGeneratable
	public interface IDocumented
	{
		Documentation Doc { get; }
	}

	// When generated as part of another generatable
	public interface IMemberGeneratable
	{
		string Name { get; }
		bool NewlineAfterGeneration(GenerationOptions opts);
		void Generate(IGeneratable parent, IndentWriter writer);
	}

	public interface ICallable : IMemberGeneratable, IDocumented
	{
		string Modifiers { get; }
		ReturnValue ReturnValue { get; }
		List<Parameter> Parameters { get; }
	}
}
